using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TimeTrackerTutorial.Views
{
    public partial class LoginEntryView : ContentView
    {
        public LoginEntryView()
        {
            InitializeComponent();
            entInput.Focused += EntInput_Focused;
            entInput.Unfocused += EntInput_Focused;
        }

        private async void EntInput_Focused(object sender, FocusEventArgs e)
        {
            if (e.IsFocused)
            {
                await Task.WhenAll(bvUnderline.FadeTo(1),
                    grdUnderline.ScaleXTo(1));
            }
            else
            {
                await Task.WhenAll(bvUnderline.FadeTo(0.5),
                    grdUnderline.ScaleXTo(0));
            }
        }
    }
}
