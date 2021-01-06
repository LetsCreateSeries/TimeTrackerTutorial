using System;
using Android.Content;
using TimeTrackerTutorial.Droid.Renderers;
using TimeTrackerTutorial.Views.Entries;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessEntryRenderer))]
namespace TimeTrackerTutorial.Droid.Renderers
{
    public class BorderlessEntryRenderer : EntryRenderer
    {
        public BorderlessEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.SetBackground(null);
                Control.SetPadding(0, 0, 0, 0);
            }
        }
    }
}
