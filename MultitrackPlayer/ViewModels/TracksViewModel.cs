using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using MultitrackPlayer.Model;
using Microsoft.Practices.Prism.ViewModel;

namespace MultitrackPlayer.ViewModels
{
    public class TracksViewModel: NotificationObject
    {
        private ObservableCollection<ITrack> _Tracks;
        public ObservableCollection<ITrack> Tracks
        {
            get
            {
                return _Tracks;
            }
            set
            {
                if (_Tracks != value)
                {
                    _Tracks = value;
                    RaisePropertyChanged();
                }
            }
        }
        
        
    }
}
