using System;
using System.Windows.Media;

namespace MultitrackPlayer.Model.Implementations
{
    public class MediaItem : IMediaItem
    {
        public string Name { get; set; }
        public string FileName { get; set; }
        public int Order { get; set; }
        public TimeSpan Duration { get; set; }
        public Color Color { get; set; }
        public ITrack Track { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
