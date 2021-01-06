using System;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace TimeTrackerTutorial.Views.SKViews
{
    public class GradientUnderlineView : Base.GradientViewBase
    {
        public GradientUnderlineView()
        {
        }

        protected override void PaintSurface(SKImageInfo info, SKCanvas canvas, SKPaint paint)
        {
            paint.Shader = SKShader.CreateLinearGradient(
                new SKPoint(0, info.Height / 2),
                new SKPoint(info.Width / 2, info.Height / 2),
                new SKColor[] { Color.Transparent.ToSKColor(), Color.White.ToSKColor() },
                new float[] { 0, 0.5f },
                SKShaderTileMode.Mirror);
            canvas.DrawRect(0, 0, info.Width, info.Height, paint);

            //paint.Shader = SKShader.CreateLinearGradient(
            //    new SKPoint(info.Width / 2, info.Height / 2),
            //    new SKPoint(info.Width, info.Height / 2),
            //    new SKColor[] { Color.White.ToSKColor(), Color.Transparent.ToSKColor() },
            //    new float[] { 0, 1 },
            //    SKShaderTileMode.Repeat);
            //canvas.DrawRect(info.Width / 2, 0, info.Width, info.Height, paint);
        }
    }
}
