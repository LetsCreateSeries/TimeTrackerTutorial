using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TimeTrackerTutorial.Views
{
    public partial class StatementEarningsView : ContentView
    {
        public static readonly BindableProperty EarningsProperty = BindableProperty.Create(
            nameof(Earnings), typeof(double), typeof(StatementEarningsView),
            propertyChanged: OnEarningsPropertyChanged);

        public double Earnings
        {
            get => (double)GetValue(EarningsProperty);
            set => SetValue(EarningsProperty, value);
        }

        private static void OnEarningsPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as StatementEarningsView;
            if (newValue is double earnings)
            {
                var formattedString = earnings.ToString("C");
                view.DollarsLabel.Text = formattedString.Substring(1, formattedString.IndexOf('.') - 1);
                view.CentsLabel.Text = formattedString.Substring(formattedString.IndexOf('.'));
            }
        }

        public StatementEarningsView()
        {
            InitializeComponent();
        }
    }
}
