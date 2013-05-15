using Microsoft.Practices.Prism.ViewModel;
using MultitrackPlayer.Model;

namespace MultitrackPlayer.ViewModels.MediaItemsTimeline
{
    public class MediaItemViewModel : NotificationObject
    {
        #region Properties
        public MediaItemsTimelineViewModel MediaItemsTimelineViewModel { get; set; }

        private IMediaItem _mediaItem;
        public IMediaItem MediaItem
        {
            get
            {
                return _mediaItem;
            }
            set
            {
                if (_mediaItem == value) return;
                _mediaItem = value;
                RaisePropertyChanged();
            }
        }

        private TrackViewModel _trackViewModel;
        public TrackViewModel TrackViewModel
        {
            get
            {
                return _trackViewModel;
            }
            set
            {
                if (_trackViewModel != value)
                {
                    _trackViewModel = value;
                    RaisePropertyChanged();
                }
            }
        }

        #endregion

        public override string ToString()
        {
            return MediaItem != null ? MediaItem.ToString() : "Null";
        }

    }
}
