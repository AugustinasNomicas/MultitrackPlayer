using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultitrackPlayer.Model;

namespace MultitrackPlayer.Services
{
    public class MediaItemsReorder
    {
        public void AttachTrack(ITrack track)
        {
            track.MediaItems.CollectionChanged += (sender, args) => Reorder(track);
        }

        private void Reorder(ITrack track)
        {
            for (var i = 0; i < track.MediaItems.Count; i++)
            {
                track.MediaItems[i].Order = i;
            }
        }
    }
}
