using System;
using SkiaSharp;
using TimeTrackerTutorial.Views.SKViews.Base;

namespace TimeTrackerTutorial.Views.SKViews
{
    public class CircleGradientView : GradientViewBase
    {
        public CircleGradientView()
        {
        }

        protected override void DrawGradient(SKImageInfo info, SKCanvas canvas, SKPaint paint)
        {
            var radius = Math.Min(info.Width, info.Height) / 2;
            canvas.DrawCircle(info.Width / 2, info.Height / 2, radius, paint);
        }
    }
}
