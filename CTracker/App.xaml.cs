using CTracker.Theme;
using System;
using Xamarin.Forms;
using CTracker.Views;
using Xamarin.Forms.Xaml;

namespace CTracker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            ThemeHelper.GetAppTheme();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
