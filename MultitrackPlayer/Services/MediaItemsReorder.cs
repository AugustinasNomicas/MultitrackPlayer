using MultitrackPlayer.Model;

namespace MultitrackPlayer.Services
{
    public class MediaItemsReorder
    {
        public void AttachTrack(ITrack track)
        {
            track.MediaItems.CollectionChanged += (sender, args) => Reorder(track);
        }

        private static void Reorder(ITrack track)
        {
            for (var i = 0; i < track.MediaItems.Count; i++)
            {
                track.MediaItems[i].Order = i;
            }
        }
    }
}
