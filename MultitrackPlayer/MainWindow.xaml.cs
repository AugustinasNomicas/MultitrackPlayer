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

namespace MultitrackPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MultitrackPlayerController _multitrackPlayerController;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            // quick and dirty multitrack player initialization
            _multitrackPlayerController = new MultitrackPlayerController();
            MultitrackPlayerView.DataContext = _multitrackPlayerController.MultitrackPlayerViewModel;
            _multitrackPlayerController.InitializeMediaElement(MultitrackPlayerView.MediaElement);
        }
    }
}
