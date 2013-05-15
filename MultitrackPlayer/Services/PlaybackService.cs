using System;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Threading;
using MultitrackPlayer.Model;
using System.Windows;

namespace MultitrackPlayer.Services
{
    public class PlaybackService
    {
        private readonly DispatcherTimer _timer;

        #region Events

        public event EventHandler PositionChanged;

        #endregion

        #region Properties

        private MediaElement MediaElement { get; set; }

        private ITrack _activeTrack;
        public ITrack ActiveTrack
        {
            get
            {
                return _activeTrack;
            }
            set
            {
                if (value != null && _activeTrack != value)
                {
                    _activeTrack = value;
                    ActiveMediaItem = null;
                    ChangeMediaItem(GetNextMediaItem());
                }
            }
        }


        private IMediaItem _activeMediaItem;
        public IMediaItem ActiveMediaItem
        {
            get
            {
                return _activeMediaItem;
            }
            set
            {
                _activeMediaItem = value;
            }
        }


        private TimeSpan _position;
        public TimeSpan Position
        {
            get { return _position; }
            set
            {
                if (_position != value)
                {
                    _position = value;
                    SetAbsolutePosition(_position);
                    RaisePositionChanged();
                }
            }
        }

        #endregion

        #region Ctor

        public PlaybackService(MediaElement mediaElement)
        {
            MediaElement = mediaElement;
            MediaElement.LoadedBehavior = MediaState.Manual;
            MediaElement.UnloadedBehavior = MediaState.Stop;
            MediaElement.MediaEnded += MediaElement_MediaEnded;
            MediaElement.MediaFailed += MediaElement_MediaFailed;
            MediaElement.ScrubbingEnabled = true;

            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(100) };
            _timer.Tick += timer_Tick;
            _timer.Start();
        }

        #endregion

        #region Methods

        public void Play()
        {
            if (ActiveTrack == null || ActiveMediaItem == null)
            {
                ChangeMediaItem(GetNextMediaItem());
            }

            if (ActiveTrack != null)
            {
                MediaElement.Play();
            }
        }

        public void Stop()
        {
            MediaElement.Stop();
            SetAbsolutePosition(TimeSpan.FromMilliseconds(0));
        }

        /// <summary>
        /// Starts next media item
        /// </summary>
        /// <returns>Returns false if no next media item exist else returns true</returns>
        public bool PlayNext()
        {
            var nextItem = GetNextMediaItem();

            if (nextItem == null) return false;

            ChangeMediaItem(nextItem);
            Play();
            return true;
        }

        #endregion

        #region Events

        void timer_Tick(object sender, EventArgs e)
        {
            if (ActiveTrack == null) return;
            if (ActiveMediaItem == null) return;

            var newPosition = GetAbsolutePosition();

            if (_position == newPosition) return;

            _position = newPosition;
            RaisePositionChanged();

            CheckForMediaItemEnd();
        }

        void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            OnMediaEnd();
        }

        void MediaElement_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show("Media failed: " + e.ErrorException);
        }

        #endregion

        #region Private methods

        private void CheckForMediaItemEnd()
        {
            if (MediaElement.Position > ActiveMediaItem.Duration)
            {
                OnMediaEnd();
            }
        }

        private void OnMediaEnd()
        {
            if (!PlayNext())
            {
                // return to start if track is ended
                ActiveMediaItem = null;
                SetAbsolutePosition(TimeSpan.FromMilliseconds(0));
                Stop();
            } 
        }

        private IMediaItem GetNextMediaItem()
        {
            return ActiveMediaItem != null
                       ? ActiveTrack.MediaItems.Where(i => i.Order > ActiveMediaItem.Order)
                                    .OrderBy(i => i.Order)
                                    .FirstOrDefault()
                       : ActiveTrack.MediaItems.OrderBy(i => i.Order).FirstOrDefault();
        }

        private void RaisePositionChanged()
        {
            var temp = PositionChanged;
            if (temp != null)
            {
                temp(this, new EventArgs());
            }
        }

        private TimeSpan GetAbsolutePosition()
        {
            var sum = ActiveTrack.MediaItems.Where(i => i.Order < ActiveMediaItem.Order).Sum(i => i.Duration.TotalMilliseconds);
            sum += MediaElement.Position.TotalMilliseconds;
            return TimeSpan.FromMilliseconds(sum);
        }

        private void SetAbsolutePosition(TimeSpan position)
        {
            var sum = TimeSpan.FromMilliseconds(0);
            foreach (var mediaItem in ActiveTrack.MediaItems.OrderBy(i => i.Order))
            {
                sum = sum.Add(mediaItem.Duration);

                if (position < sum)
                {
                    ChangeMediaItem(mediaItem);

                    var positionInMediaItem = position.Subtract(sum.Subtract(mediaItem.Duration));

                    SeekTo(positionInMediaItem);
                    break;
                }

            }
        }

        private void ChangeMediaItem(IMediaItem mediaItem)
        {
            if (mediaItem != null && ActiveMediaItem != mediaItem)
            {
                if (File.Exists(mediaItem.FileName))
                {
                    MediaElement.Source = new Uri(mediaItem.FileName, UriKind.RelativeOrAbsolute);
                    _activeMediaItem = mediaItem;
                }
                else
                {
                    throw new FileNotFoundException(string.Format("File {0} not fond", mediaItem.FileName));
                }
            }
        }

        private void SeekTo(TimeSpan time)
        {
            MediaElement.Position = time;
            _position = GetAbsolutePosition();
            RaisePositionChanged();
        }

        #endregion
    }
}
