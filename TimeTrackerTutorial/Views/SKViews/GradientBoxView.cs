using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TimeTrackerTutorial.Views.SKViews
{
    public class GradientBoxView : Base.GradientViewBase
    {
        protected override void PaintSurface(SKImageInfo info, SKCanvas canvas, SKPaint paint)
        {
            SKRect rect = new SKRect(0, 0, info.Width, info.Height);
            // Create linear gradient from top to bottom
            paint.Shader = SKShader.CreateLinearGradient(
                                new SKPoint(info.Width / 2, 0),
                                new SKPoint(info.Width / 2, info.Height),
                                new SKColor[] { StartColor.ToSKColor(), EndColor.ToSKColor() },
                                new float[] { 0, 1 },
                                SKShaderTileMode.Repeat);

            // Draw the gradient on the rectangle
            canvas.DrawRect(rect, paint);
        }
    }
}
