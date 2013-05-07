using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using MultitrackPlayer.Model;
using System.Windows;

namespace MultitrackPlayer.Services
{
    public class PlaybackServiceStoryboad
    {
        private class TimelineMapElement
        {
            public IMediaItem MediaItem { get; set; }
            public MediaElement MediaElement { get; set; }
        }

        private readonly DispatcherTimer _timer;
        private Dictionary<Timeline, TimelineMapElement> _timelineMap;

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
//                    SetAbsolutePosition(_position);
                    RaisePositionChanged();
                }
            }
        }

        #endregion

        #region Ctor

        public PlaybackServiceStoryboad(MediaElement mediaElement)
        {
            MediaElement = mediaElement;
            MediaElement.LoadedBehavior = MediaState.Manual;
            MediaElement.UnloadedBehavior = MediaState.Manual;
            MediaElement.MediaFailed += MediaElement_MediaFailed;

            _timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(100) };
            _timer.Tick += timer_Tick;
            _timer.Start();
        }

        #endregion

        #region Methods

        public void Play()
        {

        }

        public void Stop()
        {

        }

        public void Pause()
        {
            //MediaElement.Pause();
        }

        #endregion

        #region Events

        void timer_Tick(object sender, EventArgs e)
        {

        }

        void MediaElement_MediaFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show("Media failed: " + e.ErrorException);
        }

        void Storyboard_CurrentStateInvalidated(object sender, EventArgs e)
        {
            var clock = (Clock)sender;
            if (clock.CurrentState == ClockState.Active)
            {
                //ActiveMediaItem = _timelineMap[clock.Timeline];
            }
        }

        void Storyboard_CurrentTimeInvalidated(object sender, EventArgs e)
        {
            var clock = (Clock)sender;
            if (clock.CurrentTime.HasValue)
            {
                _position = clock.CurrentTime.Value;
                RaisePositionChanged();
            }
        }

        #endregion

        #region Private methods

        private void BuildStoryboad()
        {
            _timelineMap = new Dictionary<Timeline, TimelineMapElement>();

            var storyboard = new Storyboard { SlipBehavior = SlipBehavior.Slip };
            storyboard.CurrentStateInvalidated += Storyboard_CurrentStateInvalidated;
            storyboard.CurrentTimeInvalidated += Storyboard_CurrentTimeInvalidated;
            
            foreach (var mediaItem in ActiveTrack.MediaItems.OrderBy(i => i.Order))
            {
                var startTimeAndDuration = GetStartTimeAndDuration(mediaItem);

                var mediaTimeline = new MediaTimeline
                    {
                        Source = new Uri(mediaItem.FileName, UriKind.RelativeOrAbsolute),
                        BeginTime = startTimeAndDuration.Item1,
                        Duration = startTimeAndDuration.Item2,
                    };
                 mediaTimeline.CreateClock();
                
                
                storyboard.Children.Add(mediaTimeline);
                //_timelineMap.Add(mediaTimeline, mediaItem);
            }

        }

        private void RaisePositionChanged()
        {
            var temp = PositionChanged;
            if (temp != null)
            {
                temp(this, new EventArgs());
            }
        }

        private Tuple<TimeSpan, TimeSpan> GetStartTimeAndDuration(IMediaItem mediaItem)
        {
            return
                new Tuple<TimeSpan, TimeSpan>(
                   TimeSpan.FromMilliseconds(ActiveTrack.MediaItems.OrderBy(i => i.Order)
                               .Where(i => i.Order < mediaItem.Order)
                               .Sum(i => i.Duration.TotalMilliseconds)),
                    mediaItem.Duration);
        }

        private void SeekTo(TimeSpan time)
        {

        }

        #endregion
    }
}
