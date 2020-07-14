using System;
using System.Windows.Input;
using TimeTrackerTutorial.PageModels.Base;
using Xamarin.Forms;

namespace TimeTrackerTutorial.ViewModels
{
    public class LoginOptionViewModel : ExtendedBindableObject
    {
        private Color _backgroundColor;
        public Color BackgroundColor
        {
            get => _backgroundColor;
            set => SetProperty(ref _backgroundColor, value);
        }

        private string _text;
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        private string _icon;
        public string Icon
        {
            get => _icon;
            set => SetProperty(ref _icon, value);
        }

        private ICommand _tapCommand;
        public ICommand TapCommand
        {
            get => _tapCommand;
            set => SetProperty(ref _tapCommand, value);
        }

        public LoginOptionViewModel(string text, Action tapAction, Color bgColor, string icon = "")
        {
            Text = text;
            TapCommand = new Command(tapAction);
            BackgroundColor = bgColor;
            Icon = icon;
        }
    }
}
