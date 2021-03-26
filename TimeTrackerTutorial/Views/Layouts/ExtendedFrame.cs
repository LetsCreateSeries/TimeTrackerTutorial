using System;
using Xamarin.Forms;

namespace TimeTrackerTutorial.Views.Layouts
{
    public class ExtendedFrame : Frame
    {
        public static readonly BindableProperty ShadowOpacityProperty = BindableProperty.Create(
            nameof(ShadowOpacity), typeof(float), typeof(ExtendedFrame), 1.0f);
        public static readonly BindableProperty ShadowOffsetProperty = BindableProperty.Create(
            nameof(ShadowOffset), typeof(Point), typeof(ExtendedFrame), Point.Zero);
        public static readonly BindableProperty ShadowRadiusProperty = BindableProperty.Create(
            nameof(ShadowRadius), typeof(float), typeof(ExtendedFrame), 3.0f);

        public float ShadowOpacity
        {
            get => (float)GetValue(ShadowOpacityProperty);
            set => SetValue(ShadowOpacityProperty, value);
        }

        public float ShadowRadius
        {
            get => (float)GetValue(ShadowRadiusProperty);
            set => SetValue(ShadowRadiusProperty, value);
        }

        public Point ShadowOffset
        {
            get => (Point)GetValue(ShadowOffsetProperty);
            set => SetValue(ShadowOffsetProperty, value);
        }
    }
}
