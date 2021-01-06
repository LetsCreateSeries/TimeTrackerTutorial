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
            etInput.Focused += EtInput_Focused;
            etInput.Unfocused += EtInput_Unfocused;
        }

        private void EtInput_Unfocused(object sender, FocusEventArgs e)
        {
            Animate(false);
        }

        private void EtInput_Focused(object sender, FocusEventArgs e)
        {
            Animate(true);
        }

        async void Animate(bool focused)
        {
            if (focused)
                await Task.WhenAny(bvUnderline.FadeTo(1, 250),
                    grdUnderline.ScaleXTo(1));
            else
                await Task.WhenAny(bvUnderline.FadeTo(0.5, 100),
                    grdUnderline.ScaleXTo(0, 100));
        }
    }
}
