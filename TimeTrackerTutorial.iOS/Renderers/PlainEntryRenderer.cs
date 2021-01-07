using System;
using TimeTrackerTutorial.iOS.Renderers;
using TimeTrackerTutorial.Views.Entries;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(PlainEntry), typeof(PlainEntryRenderer))]
namespace TimeTrackerTutorial.iOS.Renderers
{
    public class PlainEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.BorderStyle = UIKit.UITextBorderStyle.None;
            }
        }
    }
}
