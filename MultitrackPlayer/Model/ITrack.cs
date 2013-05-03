using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MultitrackPlayer.Model
{
    public interface ITrack
    {
        string Name { get; set; }
        ObservableCollection<IMediaItem> MediaItems { get; set; }
    }
}
