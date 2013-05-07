using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.ViewModel;

namespace MultitrackPlayer.ViewModels.MediaItemsTimeline
{
    public class MediaItemsTimelineViewModel : NotificationObject
    {
        #region Properties
        private double _zoomFactor = 1.0;
        public double ZoomFactor
        {
            get
            {
                return _zoomFactor;
            }
            set
            {
                _zoomFactor = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<TrackViewModel> _tracks;
        public ObservableCollection<TrackViewModel> Tracks
        {
            get
            {
                return _tracks;
            }
            set
            {
                if (_tracks == value) return;
                _tracks = value;
                RaisePropertyChanged();
            }
        } 
        #endregion
    }
}
