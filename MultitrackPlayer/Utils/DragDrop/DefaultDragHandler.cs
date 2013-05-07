using System.Linq;
using System.Windows;
using TypeUtilities = MultitrackPlayer.Utils.DragDrop.Helpers.TypeUtilities;

namespace MultitrackPlayer.Utils.DragDrop
{
    public class DefaultDragHandler : IDragSource
    {
        public virtual void StartDrag(IDragInfo dragInfo)
        {
            int itemCount = dragInfo.SourceItems.Cast<object>().Count();

            if (itemCount == 1)
            {
                dragInfo.Data = dragInfo.SourceItems.Cast<object>().First();
            }
            else if (itemCount > 1)
            {
                dragInfo.Data = TypeUtilities.CreateDynamicallyTypedList(dragInfo.SourceItems);
            }

            if (dragInfo.Data != null)
            {
                if (dragInfo.Effects == DragDropEffects.None)
                    dragInfo.Effects = DragDropEffects.Copy | DragDropEffects.Move;
            }
            else
            {
                dragInfo.Effects = DragDropEffects.None;
            }
        }

        public virtual void Dropped(IDropInfo dropInfo)
        {
        }
    }
}
