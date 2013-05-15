using System.Collections.Generic;
using System.Linq;
using System.Windows;
using MultitrackPlayer.Utils.DragDrop;
using MultitrackPlayer.ViewModels.MediaItemsTimeline;

namespace MultitrackPlayer.DragDrop
{
    public class TrackViewModelDropHandler : IDropTarget
    {
        private readonly TrackViewModel _trackViewModel;
        public TrackViewModelDropHandler(TrackViewModel trackViewModel)
        {
            _trackViewModel = trackViewModel;
        }

        public void DragOver(IDropInfo dropInfo)
        {
            if (dropInfo.Data is IList<MediaItemViewModel> || dropInfo.Data is MediaItemViewModel)
            {
                dropInfo.Effects = DragDropEffects.Copy | DragDropEffects.Move;
                dropInfo.DropTargetAdorner = DropTargetAdorners.Insert;
            }
        }

        public void Drop(IDropInfo dropInfo)
        {
            var insertIndex = dropInfo.InsertIndex;

            MediaItemViewModel[] mediaItemViewModels = { dropInfo.Data as MediaItemViewModel };

            var destinationList = _trackViewModel.Track.MediaItems;
            var sourceList = mediaItemViewModels.First().TrackViewModel.Track.MediaItems;

            foreach (var index in mediaItemViewModels.Select(o => sourceList.IndexOf(o.MediaItem)).Where(index => index != -1))
            {
                sourceList.RemoveAt(index);

                if (sourceList == destinationList && index < insertIndex)
                {
                    --insertIndex;
                }
            }

            foreach (var o in mediaItemViewModels)
            {
                if (insertIndex < destinationList.Count)
                    destinationList.Insert(insertIndex++, o.MediaItem);
                else
                    destinationList.Add(o.MediaItem);
            }
        }

        public void DragEnter(IDropInfo dropInfo)
        {
        }

        public void DragLeave(IDropInfo dropInfo)
        {
        }
    }
}
