using System;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace TimeTrackerTutorial.Views.SKViews.Base
{
    public abstract class SKViewBase : ContentView
    {
        public SKViewBase()
        {
            var canvas = new SKCanvasView();
            canvas.PaintSurface += Canvas_PaintSurface;
            Content = canvas;
        }

        protected abstract void OnPaintSurface(SKImageInfo info, SKCanvas canvas, SKPaint paint);

        private void Canvas_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKCanvas canvas = e.Surface.Canvas;

            canvas.Clear();

            using (var paint = new SKPaint())
            {
                OnPaintSurface(info, canvas, paint);
            }
        }
    }
}
