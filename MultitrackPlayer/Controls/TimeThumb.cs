using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace MultitrackPlayer.Controls
{
    class TimeThumb : Thumb
    {
        private bool _isInDrag = false;
        #region Properties


        public int MillisecondsPerPixel
        {
            get { return (int)GetValue(MillisecondsPerPixelProperty); }
            set { SetValue(MillisecondsPerPixelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MillisecondsPerPixel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MillisecondsPerPixelProperty =
            DependencyProperty.Register("MillisecondsPerPixel", typeof(int), typeof(TimeThumb), new PropertyMetadata(50));

        public TimeSpan Value
        {
            get { return (TimeSpan)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(TimeSpan), typeof(Thumb), new FrameworkPropertyMetadata(TimeSpan.FromMilliseconds(0), ValuePropertyChanged) { BindsTwoWayByDefault = true });

        public TimeSpan MaxValue
        {
            get { return (TimeSpan)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); }
        }

        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(TimeSpan), typeof(Thumb), new PropertyMetadata(TimeSpan.FromMilliseconds(0)));

        public double Zoom
        {
            get { return (double)GetValue(ZoomProperty); }
            set { SetValue(ZoomProperty, value); }
        }

        public static readonly DependencyProperty ZoomProperty =
            DependencyProperty.Register("Zoom", typeof(double), typeof(TimeThumb), new FrameworkPropertyMetadata(1.0, ValuePropertyChanged));

        public double Position
        {
            get
            {
                return Margin.Left;
            }
            set
            {
                if (Math.Abs(Margin.Left - value) > 000.1)
                {
                    var frameworkElement = Parent as FrameworkElement;
                    if (frameworkElement != null && (value >= 0 && value <= frameworkElement.ActualWidth - ActualWidth))
                    {
                        Margin = new Thickness(value, 0, 0, 0);
                    }
                }
            }
        }
        #endregion

        #region Ctor
        public TimeThumb()
        {
            DragDelta += TimeThumb_DragDelta;
            PreviewMouseUp += TimeThumb_MouseUp;
            PreviewMouseDown += TimeThumb_MouseDown;
            HorizontalAlignment = HorizontalAlignment.Left;
            Cursor = Cursors.SizeWE;
            
        }
        #endregion

        private static void ValuePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            ((TimeThumb)sender).UpdatePositionFromValue();
        }

        protected override void OnVisualParentChanged(DependencyObject oldParent)
        {
            base.OnVisualParentChanged(oldParent);

            if (oldParent != null)
                ((FrameworkElement)Parent).SizeChanged -= TimeThumb_SizeChanged;

            var frameworkElement = Parent as FrameworkElement;
            if (frameworkElement != null)
                frameworkElement.SizeChanged += TimeThumb_SizeChanged;
        }

        void TimeThumb_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdatePositionFromValue();
        }

        void TimeThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Position += e.HorizontalChange;
        }

        void TimeThumb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CaptureMouse();
            _isInDrag = true;
        }


        void TimeThumb_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Value = PositionToTime(Position);
            ReleaseMouseCapture();
            _isInDrag = false;
        }

        private void UpdatePositionFromValue()
        {
            if (!_isInDrag)
            Position = TimeToPosition(Value);
        }

        private double TimeToPosition(TimeSpan time)
        {
            return time.TotalMilliseconds / (MillisecondsPerPixel / Zoom);
        }

        private TimeSpan PositionToTime(double position)
        {
            return TimeSpan.FromMilliseconds(position * (MillisecondsPerPixel / Zoom));
        }

    }
}
