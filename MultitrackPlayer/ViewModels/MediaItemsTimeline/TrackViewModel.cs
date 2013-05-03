using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultitrackPlayer.Model;

namespace MultitrackPlayer.ViewModels.MediaItemsTimeline
{
    public class TrackViewModel: NotificationObject
    {
        public ObservableCollection<MediaItemViewModel> MediaItems { get; set; }
    }
}
