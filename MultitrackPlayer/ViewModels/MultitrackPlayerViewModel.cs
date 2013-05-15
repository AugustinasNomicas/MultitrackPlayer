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

        public ICommand PlayCommand { get; set; }
        public ICommand StopCommand { get; set; }

        public event EventHandler UserUpdatedPosition;


        private int _millisecondsPerPixel;
        public int MillisecondsPerPixel
        {
            get
            {
                return _millisecondsPerPixel;
            }
            set
            {
                if (_millisecondsPerPixel != value)
                {
                    _millisecondsPerPixel = value;
                    RaisePropertyChanged();
                }
            }
        }
        

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


        private TimeSpan _totalLength = TimeSpan.FromSeconds(360);
        public TimeSpan TotalLength
        {
            get
            {
                return _totalLength;
            }
            set
            {
                if (_totalLength != value)
                {
                    _totalLength = value;
                    RaisePropertyChanged();
                }
            }
        }
        

        private TimeSpan _playbackPosition;
        public TimeSpan PlaybackPosition
        {
            get
            {
                return _playbackPosition;
            }
            set
            {
                if (_playbackPosition != value)
                {
                    // playback position updated came from user
                    _playbackPosition = value;
                    RaisePropertyChanged();
                    OnUserUpdatedPosition();
                }
            }
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
