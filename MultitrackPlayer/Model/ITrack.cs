using System.Collections.ObjectModel;

namespace MultitrackPlayer.Model
{
    public interface ITrack
    {
        string Name { get; set; }
        ObservableCollection<IMediaItem> MediaItems { get; set; }
    }
}
