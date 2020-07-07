using System;
using CoreAnimation;
using TimeTrackerTutorial.iOS.Renderers;
using TimeTrackerTutorial.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(HoursProgressView), typeof(HoursProgressViewRenderer))]
namespace TimeTrackerTutorial.iOS.Renderers
{
    public class HoursProgressViewRenderer : ViewRenderer
    {
        private CAShapeLayer _backgroundLayer;
        private CAShapeLayer _foregroundLayer;

        public HoursProgressViewRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                e.NewElement.SizeChanged += NewElement_SizeChanged;
            }

            if (e.OldElement != null)
            {
                e.OldElement.SizeChanged -= NewElement_SizeChanged;
            }
        }

        private void NewElement_SizeChanged(object sender, EventArgs e)
        {
            if (_backgroundLayer != null)
            {
                _backgroundLayer.RemoveFromSuperLayer();
            }

            if (_foregroundLayer != null)
            {
                _foregroundLayer.RemoveFromSuperLayer();
            }

            var view = Element as HoursProgressView;
            var backgroundPath = new UIBezierPath();
            backgroundPath.MoveTo(new CoreGraphics.CGPoint(0, view.Height / 2));
            backgroundPath.AddLineTo(new CoreGraphics.CGPoint(view.Width, view.Height / 2));
            backgroundPath.LineWidth = 5;
            _backgroundLayer = new CAShapeLayer();
            _backgroundLayer.Path = backgroundPath.CGPath;
            _backgroundLayer.StrokeColor = view.BarColor.ToCGColor();

            Layer.AddSublayer(_backgroundLayer);

            var currentProgressWidth = (view.Current - view.Min) / (view.Max - view.Min);
            var foregroundPath = new UIBezierPath();
            foregroundPath.MoveTo(new CoreGraphics.CGPoint(0, view.Height / 2));
            foregroundPath.AddLineTo(new CoreGraphics.CGPoint(view.Width * currentProgressWidth, view.Height / 2));

            _foregroundLayer = new CAShapeLayer();
            foregroundPath.LineWidth = 5;
            _foregroundLayer.Path = foregroundPath.CGPath;
            _foregroundLayer.StrokeColor = view.FillColor.ToCGColor();

            Layer.AddSublayer(_foregroundLayer);

        }
    }
}
