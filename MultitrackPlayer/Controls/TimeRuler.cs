using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MultitrackPlayer.Controls
{
    public class TimeRuler : Control
    {
        public const int MillisecondsPerPixel = 50;

        #region Properties

        #region Length
        /// <summary>
        /// Gets or sets the length of the ruler. Default value is 15minutes
        /// </summary>
        public TimeSpan Length
        {
            get { return (TimeSpan)GetValue(LengthProperty); }
            set { SetValue(LengthProperty, value); }
        }


        public static readonly DependencyProperty LengthProperty =
            DependencyProperty.Register("Length", typeof(TimeSpan), typeof(TimeRuler),
            new FrameworkPropertyMetadata(new TimeSpan(0, 0, 15, 0),
            FrameworkPropertyMetadataOptions.AffectsRender));
        #endregion

        #region Zoom
        /// <summary>
        /// Gets or sets the zoom factor for the ruler. The default value is 1.0. 
        /// </summary>
        public double Zoom
        {
            get
            {
                return (double)GetValue(ZoomProperty);
            }
            set
            {
                SetValue(ZoomProperty, value);
                InvalidateVisual();
            }
        }

        /// <summary>
        /// Identifies the Zoom dependency property.
        /// </summary>
        public static readonly DependencyProperty ZoomProperty =
            DependencyProperty.Register("Zoom", typeof(double), typeof(TimeRuler),
            new FrameworkPropertyMetadata(1.0,
                FrameworkPropertyMetadataOptions.AffectsRender));

        #endregion

        #region LabelStep

        /// <summary>
        /// Gets or sets label step size in pixels
        /// </summary>
        public int LabelStep
        {
            get { return (int)GetValue(LabelStepProperty); }
            set { SetValue(LabelStepProperty, value); }
        }


        public static readonly DependencyProperty LabelStepProperty =
            DependencyProperty.Register("LabelStep", typeof(int), typeof(TimeRuler), new FrameworkPropertyMetadata(100,
                FrameworkPropertyMetadataOptions.AffectsRender));


        #endregion

        #endregion

        #region Methods

        /// <summary>
        /// Render time labels
        /// </summary>
        /// <param name="drawingContext">The drawing instructions for a specific element. This context is provided to the layout system.</param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (Zoom == 0)
                Zoom = 1;

            var millisecondsPerPixelScaled = MillisecondsPerPixel * Zoom;
            var lengthInPixels = Length.TotalMilliseconds / millisecondsPerPixelScaled;

            for (double i = 0; i < lengthInPixels; i = i + LabelStep)
            {
                RenderLabel(TimeSpan.FromMilliseconds(i * MillisecondsPerPixel), i * Zoom, drawingContext);
            }

        }

        /// <summary>
        /// Render text label
        /// </summary>
        /// <param name="labelTime">Timespan to render</param>
        /// <param name="xPosition">Label position</param>
        /// <param name="drawingContext">Drawing context from OnRender method</param>
        private void RenderLabel(TimeSpan labelTime, double xPosition, DrawingContext drawingContext)
        {
            drawingContext.DrawText(GetFormattedText(labelTime.ToString(@"mm\:ss\.ff")), new Point(xPosition, 0));
        }

        /// <summary>
        /// Measures an instance during the first layout pass prior to arranging it.
        /// </summary>
        /// <param name="availableSize">A maximum Size to not exceed.</param>
        /// <returns>The maximum Size for the instance.</returns>
        protected override Size MeasureOverride(Size availableSize)
        {
            return new Size(Length.TotalMilliseconds / MillisecondsPerPixel * Zoom, GetFormattedText("00:00").Height);
        }

        private FormattedText GetFormattedText(string text)
        {
            return new FormattedText(text, CultureInfo.CurrentCulture,
                           FlowDirection.LeftToRight,
                           new Typeface(FontFamily, FontStyle, FontWeight, FontStretch), FontSize, Foreground);
        }

        #endregion
    }
}
