using CTracker.Controls;
using CTracker.Helper;
using CTracker.Theme;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CTracker.ViewModels
{
 public class SettingsViewModel : BaseViewModel
    {

        bool _isLightTheme;
        public bool IsLightTheme
        {
            get { return _isLightTheme; }
            set
            {
                _isLightTheme = value;
                OnPropertyChanged();
                if (IsLightTheme)
                {
                    IsDarkTheme = false;
                    IsSystemPreferredTheme = false;
                }
            }
        }


        bool _isDarkTheme;
        public bool IsDarkTheme
        {
            get { return _isDarkTheme; }
            set
            {
                _isDarkTheme = value;
                OnPropertyChanged();
                if (IsDarkTheme)
                {
                    IsLightTheme = false;
                    IsSystemPreferredTheme = false;
                }
            }
        }


        bool _isSystemPreferredTheme;
        public bool IsSystemPreferredTheme
        {
            get { return _isSystemPreferredTheme; }
            set
            {
                _isSystemPreferredTheme = value;
                OnPropertyChanged();
                if (IsSystemPreferredTheme)
                {
                    IsLightTheme = false;
                    IsDarkTheme = false;
                }
            }
        }








        void GetSettings()
        {
            GetUser();
            GetThemeSetting();
        }


        void GetUser()
        {
            string isloggedIn = Setting.GetSetting(Setting.AppPrefrences.IsLoggedIn);

        }




        void GetThemeSetting()
        {
            string theme = Setting.GetSetting(Setting.AppPrefrences.AppTheme);

            var appTheme = EnumsHelper.ConvertToEnum<Setting.Theme>(theme);

            switch (appTheme)
            {
                case Setting.Theme.LightTheme:
                    IsLightTheme = true;
                    break;
                case Setting.Theme.DarkTheme:
                    IsDarkTheme = true;
                    break;
                case Setting.Theme.SystemPreferred:
                    IsSystemPreferredTheme = true;
                    break;
                default:
                    IsSystemPreferredTheme = true;
                    break;
            }
        }

        /// <summary>
        /// Function to change user's Theme in realtime 
        /// when user chooses a  different Theme preference
        /// </summary>
        void ChangeTheme(string theme)
        {
            var appTheme = EnumsHelper.ConvertToEnum<Setting.Theme>(theme);

            switch (appTheme)
            {
                case Setting.Theme.LightTheme:
                    IsLightTheme = true;
                    ThemeHelper.ChangeToLightTheme();
                    break;
                case Setting.Theme.DarkTheme:
                    IsDarkTheme = true;
                    ThemeHelper.ChangeToDarkTheme();
                    break;
                case Setting.Theme.SystemPreferred:
                    IsSystemPreferredTheme = true;
                    ThemeHelper.ChangeToSystemPreferredTheme();
                    break;
                default:
                    IsSystemPreferredTheme = true;
                    ThemeHelper.ChangeToSystemPreferredTheme();
                    break;
            }
        }




        /// <summary>
        /// Command to change theme
        /// </summary>
        ICommand _themeChangeCommand = null;

        public ICommand ThemeChangeCommand
        {
            get
            {
                return _themeChangeCommand ?? (_themeChangeCommand =
                                          new Xamarin.Forms.Command((object obj) => ChangeTheme((string)obj)));
            }
        }



        /// <summary>
        /// Gets an Instance of this class
        /// </summary>
        public static SettingsViewModel Instance { get; } = new SettingsViewModel();

    }
}
