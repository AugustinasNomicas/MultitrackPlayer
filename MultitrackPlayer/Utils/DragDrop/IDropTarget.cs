using System.Windows;

namespace MultitrackPlayer.Utils.DragDrop
{
    /// <summary>
    /// Interface implemented by Drop Handlers.
    /// </summary>
    public interface IDropTarget
    {
        /// <summary>
        /// Updates the current drag state.
        /// </summary>
        /// 
        /// <param name="dropInfo">
        ///   Information about the drag.
        /// </param>
        /// 
        /// <remarks>
        /// To allow a drop at the current drag position, the <see cref="MultitrackPlayer.Utils.DragDrop.DropInfo.Effects"/> property on 
        /// <paramref name="dropInfo"/> should be set to a value other than <see cref="DragDropEffects.None"/>
        /// and <see cref="MultitrackPlayer.Utils.DragDrop.DropInfo.Data"/> should be set to a non-null value.
        /// </remarks>
        void DragOver(MultitrackPlayer.Utils.DragDrop.IDropInfo dropInfo);

        /// <summary>
        /// Performs a drop.
        /// </summary>
        /// 
        /// <param name="dropInfo">
        ///   Information about the drop.
        /// </param>
        void Drop(MultitrackPlayer.Utils.DragDrop.IDropInfo dropInfo);

        void DragEnter(MultitrackPlayer.Utils.DragDrop.IDropInfo dropInfo);
        void DragLeave(MultitrackPlayer.Utils.DragDrop.IDropInfo dropInfo);
    }
}
