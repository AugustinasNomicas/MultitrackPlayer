using System;
using System.Windows.Media;

namespace MultitrackPlayer.Model
{
    public interface IMediaItem
    {
        string Name { get; set; }
        string FileName { get; set; }
        int Order { get; set; }
        TimeSpan Duration { get; set; }
        Color Color { get; set; }
        ITrack Track { get; set; }
    }
}
