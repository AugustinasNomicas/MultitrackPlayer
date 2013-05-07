using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Controls;
using MultitrackPlayer.DragDrop;
using MultitrackPlayer.Model;
using MultitrackPlayer.Services;
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

        private PlaybackService _playbackService;
        private readonly MediaItemsReorder _mediaItemsReorder;

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
            _mediaItemsReorder = new MediaItemsReorder();

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
            _tracksViewModel = new TracksViewModel
            {
                Tracks = _tracks,
                SelectedTrack = _tracks.FirstOrDefault(),
            };
        }

        private void BuildMultitrackPlayerViewModel()
        {
            _multitrackPlayerViewModel = new MultitrackPlayerViewModel
                {
                    TracksViewModel = _tracksViewModel,
                    MediaItemsTimelineViewModel = _mediaItemsTimelineViewModel,
                    ZoomInCommand = new DelegateCommand(ExecuteZoomInCommand),
                    ZoomOutCommand = new DelegateCommand(ExecuteZoomOutCommand),
                    PlayCommand = new DelegateCommand(ExecutePlayCommand),
                    StopCommand = new DelegateCommand(ExecuteStopCommand)
                };

            _multitrackPlayerViewModel.UserUpdatedPosition += (sender, args) => _playbackService.Position = _multitrackPlayerViewModel.PlaybackPosition;
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
            var trackViewModel = new TrackViewModel {
                MediaItems = new ObservableCollection<MediaItemViewModel>(),
                Track = track
            };

            trackViewModel.DropHandler = new TrackViewModelDropHandler(trackViewModel);

            CollectionObserver.BindCollection(trackViewModel.MediaItems,
                                              track.MediaItems,
                                              mediaItem => BuildMediaItemsTimelineMediaItemViewModel(mediaItem, mediaItemsTimelineViewModel, trackViewModel));
            return trackViewModel;
        }

        private MediaItemViewModel BuildMediaItemsTimelineMediaItemViewModel(IMediaItem mediaItem, MediaItemsTimelineViewModel mediaItemsTimelineViewModel, TrackViewModel trackViewModel)
        {
            return new MediaItemViewModel
            {
                MediaItem = mediaItem,
                MediaItemsTimelineViewModel = mediaItemsTimelineViewModel,
                TrackViewModel = trackViewModel
            };
        }

        #endregion

        #region Model building

        private void BuildModels()
        {
            _tracks = TestData.GenerateData();
            _tracks.ToList().ForEach(t => _mediaItemsReorder.AttachTrack(t));
        }


        #endregion

        #region Public methods

        public void InitializeMediaElement(MediaElement mediaElement)
        {
            _playbackService = new PlaybackService(mediaElement);
            _playbackService.PositionChanged +=
                (sender, args) => _multitrackPlayerViewModel.PlaybackPosition = _playbackService.Position;

            _tracksViewModel.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName == "SelectedTrack")
                        _playbackService.ActiveTrack = _tracksViewModel.SelectedTrack;
                };

            _playbackService.ActiveTrack = _tracksViewModel.SelectedTrack;
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

        private void ExecutePlayCommand()
        {
            _playbackService.Play();
        }

        private void ExecuteStopCommand()
        {
            _playbackService.Stop();
        }

        #endregion
    }
}
