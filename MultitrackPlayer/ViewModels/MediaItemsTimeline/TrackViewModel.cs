using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.ViewModel;
using MultitrackPlayer.DragDrop;
using MultitrackPlayer.Model;

namespace MultitrackPlayer.ViewModels.MediaItemsTimeline
{
    public class TrackViewModel : NotificationObject
    {
        public ObservableCollection<MediaItemViewModel> MediaItems { get; set; }
        public TrackViewModelDropHandler DropHandler { get; set; }
        public ITrack Track { get; set; }
    }
}
