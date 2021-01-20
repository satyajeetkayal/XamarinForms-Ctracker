using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CTracker.Droid.Utlis;
using CTracker.Interface;
using Plugin.CurrentActivity;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(StatusBarHelper))]

namespace CTracker.Droid.Utlis
{
   public class StatusBarHelper : IStatusBar
    {
        public void ChangeStatusBarColorToWhite()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var currentWindow = GetCurrentWindow();
                    currentWindow.DecorView.SystemUiVisibility = (StatusBarVisibility)SystemUiFlags.LightStatusBar;
                    currentWindow.SetNavigationBarColor(Android.Graphics.Color.ParseColor("#e0e0e0"));
                    currentWindow.SetTitleColor(Android.Graphics.Color.Gray);
                    currentWindow.SetStatusBarColor(Android.Graphics.Color.ParseColor("#ffffff"));
                });
            }
        }

        public void ChangeStatusBarColorToBlack()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var currentWindow = GetCurrentWindow();
                    currentWindow.DecorView.SystemUiVisibility = StatusBarVisibility.Visible;
                    currentWindow.SetNavigationBarColor(Android.Graphics.Color.Black);
                    currentWindow.SetTitleColor(Android.Graphics.Color.White);
                    currentWindow.SetStatusBarColor(Android.Graphics.Color.ParseColor("#212121"));
                });
            }
        }

        public void HideStatusBar()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    var currentWindow = GetCurrentWindow();
                    currentWindow.DecorView.SystemUiVisibility = StatusBarVisibility.Hidden;
                    currentWindow.SetTitleColor(Android.Graphics.Color.Black);
                    currentWindow.SetNavigationBarColor(Android.Graphics.Color.Black);
                    currentWindow.SetStatusBarColor(Android.Graphics.Color.Black);
                });
            }
        }

        Window GetCurrentWindow()
        {
            var window = CrossCurrentActivity.Current.Activity.Window;

            // clear FLAG_TRANSLUCENT_STATUS flag:
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);

            // add FLAG_DRAWS_SYSTEM_BAR_BACKGROUNDS flag to the window
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            return window;
        }



    }
}