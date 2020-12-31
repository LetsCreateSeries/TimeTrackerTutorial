using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimeTrackerTutorial.Views.Labels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DollarsLabel : ContentView
    {
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
            nameof(TextColor), typeof(Color), typeof(DollarsLabel), Color.White,
            propertyChanged: (b,o,n) => ((DollarsLabel)b).OnTextColorChanged((Color)n));
        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            nameof(FontSize), typeof(int), typeof(DollarsLabel), 50,
            propertyChanged: (b, o, n) => ((DollarsLabel)b).OnFontSizeChanged((int)n));
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text), typeof(string), typeof(DollarsLabel), "",
            propertyChanged: (b, o, n) => ((DollarsLabel)b).OnTextChanged((string)n));

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public int FontSize
        {
            get => (int)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public DollarsLabel()
        {
            InitializeComponent();
        }

        private void OnTextColorChanged(Color n)
        {
            lblCentValue.TextColor = n;
            lblDollarSign.TextColor = n;
            lblDollarValue.TextColor = n;
        }
        private void OnFontSizeChanged(int n)
        {
            var ratio = 16 / 50 * n;
            lblCentValue.FontSize = ratio;
            lblDollarValue.FontSize = n;
            lblDollarSign.FontSize = ratio;
        }

        private void OnTextChanged(string n)
        {
            n = n.Replace("$", "");
            if (n.Contains("."))
            {
                lblDollarValue.Text = n.Substring(0, n.IndexOf("."));
                lblCentValue.Text = n.Substring(n.IndexOf('.') + 1);
            } else
            {
                lblDollarValue.Text = n;
                lblCentValue.Text = "00";
            }
        }


    }
}