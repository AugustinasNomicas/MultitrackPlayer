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
    }
}
