using System;
using SkiaSharp;

namespace TimeTrackerTutorial.Views.SKViews
{
    public class RectGradientView : Base.GradientViewBase
    {
        public RectGradientView()
        {
        }

        protected override void DrawGradient(SKImageInfo info, SKCanvas canvas, SKPaint paint)
        {
            canvas.DrawRect(0, 0, info.Width, info.Height, paint);
        }
    }
}
