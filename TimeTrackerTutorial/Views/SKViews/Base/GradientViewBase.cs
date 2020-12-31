using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TimeTrackerTutorial.Views.SKViews.Base
{
    public abstract class GradientViewBase : ContentView
    {
        public static readonly BindableProperty StartColorProperty = BindableProperty.Create(
           nameof(StartColor), typeof(Color), typeof(GradientBoxView), Color.White);
        public static readonly BindableProperty EndColorProperty = BindableProperty.Create(
            nameof(EndColor), typeof(Color), typeof(GradientBoxView), Color.White);

        public Color StartColor
        {
            get => (Color)GetValue(StartColorProperty);
            set => SetValue(StartColorProperty, value);
        }
        public Color EndColor
        {
            get => (Color)GetValue(EndColorProperty);
            set => SetValue(EndColorProperty, value);
        }

        public GradientViewBase()
        {
            var canvasView = new SKCanvasView();
            canvasView.PaintSurface += CanvasView_PaintSurface;
            Content = canvasView;
        }

        protected abstract void PaintSurface(SKImageInfo info, SKCanvas canvas, SKPaint paint);

        private void CanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            using (SKPaint paint = new SKPaint())
            {
                PaintSurface(info, canvas, paint);
            }
        }
    }
}
