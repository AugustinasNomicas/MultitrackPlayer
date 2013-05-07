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
                                            FileName = @"..\..\..\Videos\Wildlife.wmv",
                                            Name = "Wildlife.wmv"
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
                                            FileName = @"..\..\..\Videos\ss_11_20_99.wmv",
                                            Name = "ss_11_20_99.wmv"
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
                                            FileName = @"..\..\..\Videos\sample-rTR.avi",
                                            Name = @"sample-rTR.avi"
                                        },
                                    new MediaItem
                                        {
                                            Color = Colors.CadetBlue,
                                            Duration = new TimeSpan(0, 0, 15),
                                            FileName = @"..\..\..\Videos\Wildlife.wmv",
                                            Name =  @"Wildlife.wmv",
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
                                            FileName = @"..\..\..\Videos\sample-rTR.avi",
                                            Name = "sample-rTR.avi"
                                        },
                                    new MediaItem
                                        {
                                            Color = Colors.MediumSeaGreen,
                                            Duration = new TimeSpan(0, 0, 15),
                                            FileName = @"..\..\..\Videos\Wildlife.wmv",
                                            Name = "Wildlife.wmv",
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
                                             FileName = @"..\..\..\Videos\Wildlife.wmv",
                                            Name = "Wildlife.wmv"
                                        },
                                    new MediaItem
                                        {
                                            Color = Colors.MediumSeaGreen,
                                            Duration = new TimeSpan(0, 0, 15),
                                             FileName = @"..\..\..\Videos\Wildlife.wmv",
                                            Name = "Wildlife.wmv",
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
                                            FileName = @"..\..\..\Videos\Wildlife.wmv",
                                            Name = "Wildlife.wmv"
                                        },
                                    new MediaItem
                                        {
                                            Color = Colors.DarkOrange,
                                            Duration = new TimeSpan(0, 0, 7),
                                            FileName = @"..\..\..\Videos\clipcanvas_14348_WMV_320x180.wmv",
                                            Name = "clipcanvas_14348_WMV_320x180.wmv",
                                            Order = 1
                                        },
                                    new MediaItem
                                        {
                                            Color = Colors.MediumSeaGreen,
                                            Duration = new TimeSpan(0, 0, 7),
                                            FileName = @"..\..\..\Videos\tl_08_15_01.wmv",
                                            Name = "tl_08_15_01.wmv",
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
                                            FileName = @"..\..\..\Videos\tl_08_15_01.wmv",
                                            Name = "tl_08_15_01.wmv"
                                        },
                                    new MediaItem
                                        {
                                            Color = Colors.DarkOrange,
                                            Duration = new TimeSpan(0, 0, 10),
                                            FileName = @"..\..\..\Videos\clipcanvas_14348_WMV_320x180.wmv",
                                            Name = "clipcanvas_14348_WMV_320x180.wmv",
                                            Order = 1
                                        },
                                    new MediaItem
                                        {
                                            Color = Colors.CadetBlue,
                                            Duration = new TimeSpan(0, 0, 10),
                                            FileName = @"..\..\..\Videos\ss_11_20_99.wmv",
                                            Name = "ss_11_20_99.wmv",
                                            Order = 2
                                        }
                                }
                        }

                };
            return ret;
        }
    }
}
