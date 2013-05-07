using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MultitrackPlayer.Views
{
    /// <summary>
    /// Interaction logic for MultitrackPlayerView.xaml
    /// </summary>
    public partial class MultitrackPlayerView : UserControl
    {
        public MultitrackPlayerView()
        {
            InitializeComponent();
        }

        private void MediaItemsScroller_OnScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var scrollViewer = sender as ScrollViewer;
            if (scrollViewer != null)
                TracksScroller.ScrollToVerticalOffset(scrollViewer.VerticalOffset);
        }

        private void TracksScroller_OnScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var scrollViewer = sender as ScrollViewer;
            if (scrollViewer != null)
                MediaItemsScroller.ScrollToVerticalOffset(scrollViewer.VerticalOffset);
        }

        private void TimeRuler_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                TimeThumb.Position = e.GetPosition(TimeThumb.Parent as IInputElement).X;
            }
        }

    }
}
