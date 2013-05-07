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
        private ObservableCollection<ITrack> _tracks;
        public ObservableCollection<ITrack> Tracks
        {
            get
            {
                return _tracks;
            }
            set
            {
                if (_tracks != value)
                {
                    _tracks = value;
                    RaisePropertyChanged();
                }
            }
        }


        private ITrack _selectedTrack;
        public ITrack SelectedTrack
        {
            get
            {
                return _selectedTrack;
            }
            set
            {
                if (_selectedTrack != value)
                {
                    _selectedTrack = value;
                    RaisePropertyChanged();
                }
            }
        }
        
        
    }
}
