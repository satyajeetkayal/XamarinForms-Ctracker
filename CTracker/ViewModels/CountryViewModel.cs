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
    public class CountryViewModel : BaseViewModel
    {


        private bool _isrefreshing = false;
        private string _confirmedCases;
        private string _deadCases;
        private string _recoveredCases;
        private string _lastUpdated;
        private string _activeCases;
        private string _newConfirmed;
        private string _newRecovered;
        private string _newDeaths;
        private string _countryRegion;

        public Command AppearingCommand => new Command(ExecuteFetchStatistics);


        public CountryViewModel(INavigation Navigation)
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
        public string ConfirmedCases
        {
            get => _confirmedCases;
            set
            {
                _confirmedCases = value;
                OnPropertyChanged();
            }
        }

        public string DeadCases
        {
            get => _deadCases;
            set
            {
                _deadCases = value;
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

        public string LastUpdated
        {
            get => _lastUpdated;
            set
            {
                _lastUpdated = value;
                OnPropertyChanged();
            }
        }

        public string ActiveCases
        {
            get => _activeCases;
            set
            {
                _activeCases = value;
                OnPropertyChanged();

            }
        }

        public string NewConfirmed
        {
            get => _newConfirmed;
            set
            {
                _newConfirmed = value;
                OnPropertyChanged();

            }
        }

        public string NewRecovered
        {
            get => _newRecovered;
            set
            {
                _newRecovered = value;
                OnPropertyChanged();
            }
        }

        public string NewDeaths
        {
            get => _newDeaths;
            set
            {
                _newDeaths = value;
                OnPropertyChanged();
            }
        }

        public string CountryRegion
        {
            get => _countryRegion;
            set
            {
                _countryRegion = value;
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

                UserDialogs.Instance.Toast("Something went wrong, please try again later.");



            }
        }


        public async Task FetchCaseFromApi()
        {
            await Task.Delay(2000);
            try
            {
                using (UserDialogs.Instance.Toast("Please Wait..."))
                {

                    var url = Links.endpoint1;

                    var response = await _httpclient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = response.Content.ReadAsStringAsync().Result;

                        var json = JsonConvert.DeserializeObject<CountryData>(content);

                        var VirusCases = json;

                        // Map values to label
                        ConfirmedCases = VirusCases.Cases.ToString("0");
                        DeadCases = VirusCases.Deaths.ToString("0");
                        RecoveredCases = VirusCases.Recovered.ToString("0");
                        //LastUpdated = VirusCases.Summary.LastUpdate.ToString();
                        ActiveCases = VirusCases.Active.ToString("0");
                        NewConfirmed = VirusCases.TodayCases.ToString("0");
                        NewDeaths = VirusCases.TodayDeaths.ToString("0");
                        NewRecovered = VirusCases.TodayRecovered.ToString("0");
                        CountryRegion = VirusCases.Country.ToString();

                        // Add date
                        var currentDate = DateTime.Now.ToString("h:mm tt");
                        LastUpdated = $"Last Updated: {currentDate}";
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

              await  UserDialogs.Instance.AlertAsync("Something went wrong, please try again later.","Error","Ok");
            }




        }
    }
}