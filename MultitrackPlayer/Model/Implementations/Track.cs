using System.Collections.ObjectModel;

namespace MultitrackPlayer.Model.Implementations
{
    public class Track: ITrack
    {
        public string Name { get; set; }
        public ObservableCollection<IMediaItem> MediaItems { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
