using CTracker.Controls;
using CTracker.Helper;
using CTracker.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CTracker.Theme
{
 public static class ThemeHelper
    {

        public static void GetAppTheme()
        {
            string theme = Setting.GetSetting(Setting.AppPrefrences.AppTheme);

            if (theme != null)
            {
                var appTheme = EnumsHelper.ConvertToEnum<Setting.Theme>(theme);

                switch (appTheme)
                {
                    case Setting.Theme.LightTheme:
                        ChangeToLightTheme();
                        break;
                    case Setting.Theme.DarkTheme:
                        ChangeToDarkTheme();
                        break;
                    case Setting.Theme.SystemPreferred:
                        ChangeToSystemPreferredTheme();
                        break;
                    default:
                        ChangeToSystemPreferredTheme();
                        break;
                }
            }
            else
            {
                ChangeToSystemPreferredTheme();
            }
        }

        /// <summary>
        /// Changes theme to Light Theme
        /// </summary>
        public static void ChangeToLightTheme()
        {
            Application.Current.Resources = new LightTheme();
            DependencyService.Get<IStatusBar>().ChangeStatusBarColorToWhite();
            Setting.AddSetting(Setting.AppPrefrences.AppTheme, EnumsHelper.ConvertToString(Setting.Theme.LightTheme));
        }


        /// <summary>
        /// Changes to Dark Theme
        /// </summary>
        public static void ChangeToDarkTheme()
        {
            Application.Current.Resources = new DarkTheme();
            DependencyService.Get<IStatusBar>().ChangeStatusBarColorToBlack();
            Setting.AddSetting(Setting.AppPrefrences.AppTheme, EnumsHelper.ConvertToString(Setting.Theme.DarkTheme));
        }

        /// <summary>
        /// Changes to SystemPreferred Theme
        /// </summary>
        public static void ChangeToSystemPreferredTheme()
        {
            Xamarin.Essentials.AppTheme appTheme = AppInfo.RequestedTheme;

            if (appTheme == Xamarin.Essentials.AppTheme.Dark)
            {
                ChangeToDarkTheme();
            }
            else if (appTheme == Xamarin.Essentials.AppTheme.Light)
            {
                ChangeToLightTheme();
            }
            else
            {
                ChangeToLightTheme();
            }

            Setting.AddSetting(Setting.AppPrefrences.AppTheme, EnumsHelper.ConvertToString(Setting.Theme.SystemPreferred));
        }

    }
}
