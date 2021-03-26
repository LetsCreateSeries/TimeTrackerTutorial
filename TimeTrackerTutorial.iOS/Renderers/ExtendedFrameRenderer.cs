using System;
using System.ComponentModel;
using System.Drawing;
using TimeTrackerTutorial.iOS.Renderers;
using TimeTrackerTutorial.Views.Layouts;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedFrame), typeof(ExtendedFrameRenderer))]
namespace TimeTrackerTutorial.iOS.Renderers
{
    public class ExtendedFrameRenderer : FrameRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                UpdateShadow();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == ExtendedFrame.ShadowOffsetProperty.PropertyName
                || e.PropertyName == ExtendedFrame.ShadowOpacityProperty.PropertyName
                || e.PropertyName == ExtendedFrame.ShadowRadiusProperty.PropertyName)
            {
                UpdateShadow();
            }
            else
            {
                base.OnElementPropertyChanged(sender, e);
            }

        }

        private void UpdateShadow()
        {
            if (Element.HasShadow)
            {
                var eFrame = Element as ExtendedFrame;
                Layer.ShadowRadius = eFrame.ShadowRadius;
                Layer.ShadowColor = UIColor.Black.CGColor;
                Layer.ShadowOpacity = eFrame.ShadowOpacity;
                Layer.ShadowOffset = new CoreGraphics.CGSize(eFrame.ShadowOffset.X, eFrame.ShadowOffset.Y);
            }
            else
            {
                Layer.ShadowOpacity = 0;
            }
        }
    }
}
