using System;
using Microsoft.Practices.Prism.ViewModel;
using MultitrackPlayer.ViewModels.MediaItemsTimeline;
using System.Windows.Input;

namespace MultitrackPlayer.ViewModels
{
    public class MultitrackPlayerViewModel : NotificationObject
    {
        public TracksViewModel TracksViewModel { get; set; }
        public MediaItemsTimelineViewModel MediaItemsTimelineViewModel { get; set; }

        public ICommand ZoomInCommand { get; set; }
        public ICommand ZoomOutCommand { get; set; }

        public ICommand PlayCommand { get; set; }
        public ICommand StopCommand { get; set; }

        public event EventHandler UserUpdatedPosition;

        public double ZoomFactor
        {
            get
            {
                return MediaItemsTimelineViewModel != null ? MediaItemsTimelineViewModel.ZoomFactor : 1;
            }
            set
            {
                if (MediaItemsTimelineViewModel == null) return;
                MediaItemsTimelineViewModel.ZoomFactor = value;
                RaisePropertyChanged();
            }
        }


        private TimeSpan _TotalLength = TimeSpan.FromSeconds(360);
        public TimeSpan TotalLength
        {
            get
            {
                return _TotalLength;
            }
            set
            {
                if (_TotalLength != value)
                {
                    _TotalLength = value;
                    RaisePropertyChanged();
                }
            }
        }
        

        private TimeSpan _PlaybackPosition;
        public TimeSpan PlaybackPosition
        {
            get
            {
                return _PlaybackPosition;
            }
            set
            {
                if (_PlaybackPosition != value)
                {
                    // playback position updated came from user
                    _PlaybackPosition = value;
                    RaisePropertyChanged();
                    OnUserUpdatedPosition();
                }
            }
        }

        public void UpdatePlaybackPositionFromMediaElement(TimeSpan position)
        {
            _PlaybackPosition = position;
            RaisePropertyChanged();
        }

        private void OnUserUpdatedPosition()
        {
            var temp = UserUpdatedPosition;
            if (temp != null)
            {
                temp(this, new EventArgs());
            }
        }

    }
}
