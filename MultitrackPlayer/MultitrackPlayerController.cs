using System;
using System.Collections.ObjectModel;
using System.Windows.Media;
using MultitrackPlayer.Model;
using MultitrackPlayer.Model.Implementations;
using MultitrackPlayer.ViewModels;
using MultitrackPlayer.ViewModels.MediaItemsTimeline;
using MultitrackPlayer.Utils;

namespace MultitrackPlayer
{
    public class MultitrackPlayerController
    {
        private const double ZoomStep = 0.02;

        private MultitrackPlayerViewModel _multitrackPlayerViewModel;
        private TracksViewModel _tracksViewModel;
        private MediaItemsTimelineViewModel _mediaItemsTimelineViewModel;

        // main data-model list where tracks and media items are kept
        // now filled with mock data
        private ObservableCollection<ITrack> _tracks;

        // Expose ViewModel for easear datacontext binding 
        // migth be changed in final version
        public MultitrackPlayerViewModel MultitrackPlayerViewModel
        {
            get { return _multitrackPlayerViewModel; }
        }

        #region Ctor

        public MultitrackPlayerController()
        {
            BuildModels();
            BuildViewModels();
        }

        #endregion

        #region ViewModels building

        private void BuildViewModels()
        {
            BuildTracksViewModel();
            BuildMediaItemsTimelineViewModels();
            BuildMultitrackPlayerViewModel();
        }

        private void BuildTracksViewModel()
        {
            _tracksViewModel = new TracksViewModel { Tracks = _tracks };
        }

        private void BuildMultitrackPlayerViewModel()
        {
            _multitrackPlayerViewModel = new MultitrackPlayerViewModel
                {
                    TracksViewModel = _tracksViewModel,
                    MediaItemsTimelineViewModel = _mediaItemsTimelineViewModel,
                    ZoomInCommand = new DelegateCommand(ExecuteZoomInCommand),
                    ZoomOutCommand = new DelegateCommand(ExecuteZoomOutCommand)
                };
        }

        private void BuildMediaItemsTimelineViewModels()
        {
            _mediaItemsTimelineViewModel = new MediaItemsTimelineViewModel
                {
                    Tracks = new ObservableCollection<TrackViewModel>()
                };

            CollectionObserver.BindCollection(_mediaItemsTimelineViewModel.Tracks, _tracks, track => BuildMediaItemsTimelineTrackViewModel(track, _mediaItemsTimelineViewModel));
        }

        private TrackViewModel BuildMediaItemsTimelineTrackViewModel(ITrack track, MediaItemsTimelineViewModel mediaItemsTimelineViewModel)
        {
            var trackViewModel = new TrackViewModel { MediaItems = new ObservableCollection<MediaItemViewModel>() };
            CollectionObserver.BindCollection(trackViewModel.MediaItems,
                                              track.MediaItems,
                                              mediaItem => BuildMediaItemsTimelineMediaItemViewModel(mediaItem, mediaItemsTimelineViewModel));
            return trackViewModel;
        }

        private MediaItemViewModel BuildMediaItemsTimelineMediaItemViewModel(IMediaItem mediaItem, MediaItemsTimelineViewModel mediaItemsTimelineViewModel)
        {
            return new MediaItemViewModel
            {
                MediaItem = mediaItem,
                MediaItemsTimelineViewModel = mediaItemsTimelineViewModel
            };
        }

        #endregion

        #region Model building

        private void BuildModels()
        {
            _tracks = TestData.GenerateData();
        }


        #endregion

        #region Commands

        private void ExecuteZoomInCommand()
        {
            _multitrackPlayerViewModel.ZoomFactor += ZoomStep;
        }

        private void ExecuteZoomOutCommand()
        {
            _multitrackPlayerViewModel.ZoomFactor -= ZoomStep;
        }

        #endregion
    }
}
