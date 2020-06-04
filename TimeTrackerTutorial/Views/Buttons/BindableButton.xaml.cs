using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimeTrackerTutorial.Views.Buttons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BindableButton : Button
    {
        public BindableButton()
        {
            InitializeComponent();
        }
    }
}