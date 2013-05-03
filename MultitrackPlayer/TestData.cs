using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using MultitrackPlayer.Model;
using MultitrackPlayer.Model.Implementations;

namespace MultitrackPlayer
{
    static class TestData
    {
        public static ObservableCollection<ITrack> GenerateData()
        {
            // generate mockup data for development
            var ret = new ObservableCollection<ITrack>
                {
                    new Track
                        {
                            Name = "Full Screen",
                            MediaItems = new ObservableCollection<IMediaItem>
                                {
                                    new MediaItem
                                        {
                                            Color = Colors.CadetBlue,
                                            Duration = new TimeSpan(0, 0, 30),
                                            FileName = string.Empty,
                                            Name = "Dodgers Logo Loop"
                                        }
                                }
                        },
                    new Track
                        {
                            Name = "Left Field Content",
                            MediaItems = new ObservableCollection<IMediaItem>
                                {
                                    new MediaItem
                                        {
                                            Color = Colors.CadetBlue,
                                            Duration = new TimeSpan(0, 0, 30),
                                            FileName = string.Empty,
                                            Name = "Facia Left Field"
                                        }
                                }
                        },
                    new Track
                        {
                            Name = "Left Field Ad",
                            MediaItems = new ObservableCollection<IMediaItem>
                                {
                                    new MediaItem
                                        {
                                            Color = Colors.CadetBlue,
                                            Duration = new TimeSpan(0, 0, 15),
                                            FileName = string.Empty,
                                            Name = "Toyota Dealers Logo"
                                        },
                                    new MediaItem
                                        {
                                            Color = Colors.CadetBlue,
                                            Duration = new TimeSpan(0, 0, 15),
                                            FileName = string.Empty,
                                            Name = "Toyota Dealers Local Sponsor",
                                            Order = 1
                                        }
                                }
                        },
                    new Track
                        {
                            Name = "Left Field Stat Area",
                            MediaItems = new ObservableCollection<IMediaItem>
                                {
                                    new MediaItem
                                        {
                                            Color = Colors.MediumSeaGreen,
                                            Duration = new TimeSpan(0, 0, 15),
                                            FileName = string.Empty,
                                            Name = "Pitcher Stats"
                                        },
                                    new MediaItem
                                        {
                                            Color = Colors.MediumSeaGreen,
                                            Duration = new TimeSpan(0, 0, 15),
                                            FileName = string.Empty,
                                            Name = "Batter Stats",
                                            Order = 1
                                        }
                                }
                        },
                    new Track
                        {
                            Name = "Center Content 8096x48",
                            MediaItems = new ObservableCollection<IMediaItem>
                                {
                                    new MediaItem
                                        {
                                            Color = Colors.MediumSeaGreen,
                                            Duration = new TimeSpan(0, 0, 15),
                                            FileName = string.Empty,
                                            Name = "Center Batting Order"
                                        },
                                    new MediaItem
                                        {
                                            Color = Colors.MediumSeaGreen,
                                            Duration = new TimeSpan(0, 0, 15),
                                            FileName = string.Empty,
                                            Name = "Center Home Run Stats",
                                            Order = 1
                                        }
                                }
                        },
                    new Track
                        {
                            Name = "Right Field Stat Aera",
                            MediaItems = new ObservableCollection<IMediaItem>
                                {
                                    new MediaItem
                                        {
                                            Color = Colors.MediumSeaGreen,
                                            Duration = new TimeSpan(0, 0, 10),
                                            FileName = string.Empty,
                                            Name = "National Scores"
                                        },
                                    new MediaItem
                                        {
                                            Color = Colors.DarkOrange,
                                            Duration = new TimeSpan(0, 0, 10),
                                            FileName = string.Empty,
                                            Name = "Arena Logo Still Graphic",
                                            Order = 1
                                        },
                                    new MediaItem
                                        {
                                            Color = Colors.MediumSeaGreen,
                                            Duration = new TimeSpan(0, 0, 10),
                                            FileName = string.Empty,
                                            Name = "American Scores",
                                            Order = 2
                                        }
                                }
                        },
                    new Track
                        {
                            Name = "Right Field Ad",
                            MediaItems = new ObservableCollection<IMediaItem>
                                {
                                    new MediaItem
                                        {
                                            Color = Colors.CadetBlue,
                                            Duration = new TimeSpan(0, 0, 10),
                                            FileName = string.Empty,
                                            Name = "Local Toyota Ad"
                                        },
                                    new MediaItem
                                        {
                                            Color = Colors.DarkOrange,
                                            Duration = new TimeSpan(0, 0, 10),
                                            FileName = string.Empty,
                                            Name = "Still Graphic",
                                            Order = 1
                                        },
                                    new MediaItem
                                        {
                                            Color = Colors.CadetBlue,
                                            Duration = new TimeSpan(0, 0, 10),
                                            FileName = string.Empty,
                                            Name = "Toyta Play of the day",
                                            Order = 2
                                        }
                                }
                        }

                };
            return ret;
        }
    }
}
