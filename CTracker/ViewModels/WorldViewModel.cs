using Acr.UserDialogs;
using CTracker.Constant;
using CTracker.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CTracker.ViewModels
{
    public class WorldViewModel : BaseViewModel
    {

        private bool _isrefreshing = false;
        private string _cases;
        private string _deathCases;
        private string _recoveredCases;
        private string _lastUpdated;

        public Command AppearingCommand => new Command(ExecuteFetchStatistics);

        public WorldViewModel(INavigation Navigation)
        {

            Navigation = navigation;
        }


        public bool IsRefreshing
        {
            get { return _isrefreshing; }

            set
            {
                _isrefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }

        }

        public string Cases
        {
            get => _cases;
            set
            {
                _cases = value;
                OnPropertyChanged();
            }
        }

        public string DeathCases
        {
            get => _deathCases;
            set
            {
                _deathCases = value;
                OnPropertyChanged();
            }
        }


        public string RecoveredCases
        {
            get => _recoveredCases;
            set
            {
                _recoveredCases = value;
                OnPropertyChanged();
            }

        }

        public string Lastupdate
        {
            get => _lastUpdated;
            set
            {
                _lastUpdated = value;
                OnPropertyChanged();

            }
        }


        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>

                {

                    IsRefreshing = true;
                    await FetchCaseFromApi();

                    IsRefreshing = false;
                    return;



                });

            }
        }

        private async void ExecuteFetchStatistics()
        {
            try
            {
                var connected = _permissionService.CheckNetworkConnectivity();
                if (connected != NetworkAccess.Internet)
                {
                    UserDialogs.Instance.Toast("No internet connection available.");

                }
                else
                {

                    await FetchCaseFromApi();
                    return;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

             await UserDialogs.Instance.AlertAsync("Something went wrong, please try again later.","Error","Ok");



            }

        }


        public async Task FetchCaseFromApi()
        {
            try
            {
                using (UserDialogs.Instance.Toast("Please Wait..."))
                {

                    var url = Links.endpoint2;

                    var response = await _httpclient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = response.Content.ReadAsStringAsync().Result;

                        var json = JsonConvert.DeserializeObject<WorldData>(content);

                        var VirusCases = json;


                        Cases = VirusCases.Cases.ToString("0");
                        DeathCases = VirusCases.Deaths.ToString("0");
                        RecoveredCases = VirusCases.Recovered.ToString("0");

                        var currentDate = DateTime.Now.ToString("h:mm tt");
                        Lastupdate = $"Last Updated: {currentDate}";
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                UserDialogs.Instance.Toast("Something went wrong, please try again later.");
            }




        }
    }
}
