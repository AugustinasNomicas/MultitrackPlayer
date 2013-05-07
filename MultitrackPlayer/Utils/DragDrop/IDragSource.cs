using System.Windows;

namespace MultitrackPlayer.Utils.DragDrop
{
    /// <summary>
    /// Interface implemented by Drag Handlers.
    /// </summary>
    public interface IDragSource
    {
        /// <summary>
        /// Queries whether a drag can be started.
        /// </summary>
        /// 
        /// <param name="dragInfo">
        /// Information about the drag.
        /// </param>
        /// 
        /// <remarks>
        /// To allow a drag to be started, the <see cref="MultitrackPlayer.Utils.DragDrop.DragInfo.Effects"/> property on <paramref name="dragInfo"/> 
        /// should be set to a value other than <see cref="DragDropEffects.None"/>. 
        /// </remarks>
        void StartDrag(MultitrackPlayer.Utils.DragDrop.IDragInfo dragInfo);

        /// <summary>
        /// Notifies the drag handler that a drop has occurred.
        /// </summary>
        /// 
        /// <param name="dropInfo">
        ///   Information about the drop.
        /// </param>
        void Dropped(MultitrackPlayer.Utils.DragDrop.IDropInfo dropInfo);
    }
}
