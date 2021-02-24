using Acr.UserDialogs;
using CTracker.Constant;
using CTracker.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CTracker.ViewModels
{
  public class CountriesViewModel : BaseViewModel
    {

        private bool _isrefreshing = false;
        private string _searchBarText;

        public Command AppearingCommand => new Command(ExecuteFetchCases);
        public Command DisAppearingCommand => new Command(ExecuteDisappearingCommand);
        public Command SearchButtonPressedCommand => new Command(ExecuteSearchButtonCommand);
        public Command TextChangedCommand => new Command(ExecuteTextChangedCommand);

        public ObservableCollection<CountriesData> CaseCollections { get; set; }

        public CountriesViewModel(INavigation Navigation)
        {
            Navigation = navigation;
            CaseCollections = new ObservableCollection<CountriesData>();
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

        public string SearchBarText
        {

            get => _searchBarText;
            set
            {
                _searchBarText = value;
                OnPropertyChanged();

            }

        }

        private string _flag;
        public string Flag
        {
            get { return _flag; }

            set
            {
                _flag = value;

                OnPropertyChanged();
            }


        }

        private int _id;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
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
        private async void ExecuteFetchCases()
        {
           
            try
            {
                var connected = _permissionService.CheckNetworkConnectivity();
                if (connected != NetworkAccess.Internet)
                {
                    UserDialogs.Instance.Toast("No Internet Connection available.");

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
                UserDialogs.Instance.Toast("Something Went Wrong, Please Try again later.");


            }
        }

        private async Task FetchCaseFromApi()
            
        {
            await Task.Delay(2000);
            try
            {
                using (UserDialogs.Instance.Toast("Please Wait..."))
                {

                    CaseCollections.Clear();

                    var url = Links.endpoint3;
                    var response = await _httpclient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {

                        var content = response.Content.ReadAsStringAsync().Result;
                        var json = JsonConvert.DeserializeObject<List<CountriesData>>(content);
                        var caseFound = new ObservableCollection<CountriesData>(json);


                        foreach (var cases in caseFound)
                        {

                            CaseCollections.Add(cases);

                        }

                    }

                }

            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await UserDialogs.Instance.AlertAsync("Something went wrong, try again later.","Error","Ok");

            }

        }

        private void ExecuteSearchButtonCommand()
        {

            GetCaseBySearch();

        }

        private async void GetCaseBySearch()
        {

            try
            {
                var keyboard = SearchBarText;
                var url = Links.endpoint3;

                var response = await _httpclient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {

                    var content = response.Content.ReadAsStringAsync().Result;
                    var json = JsonConvert.DeserializeObject<List<CountriesData>>(content);

                    CaseCollections.Clear();

                    var caseFound = new ObservableCollection<CountriesData>(json);

                    var searchCountry = caseFound.Where(c => c.Country.ToLower().Contains(SearchBarText.ToLower()));

                    foreach (var country in searchCountry)
                    {
                        CaseCollections.Add(country);

                    }

                    var searchCountryCount = new List<CountriesData>(searchCountry).Count;

                }



            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);

                await UserDialogs.Instance.AlertAsync("Something went worng, Please try again later.", "Error", "Ok");


            }

        }

        private async void ExecuteTextChangedCommand()
        {
            if (_searchBarText == string.Empty)
            {

                CaseCollections.Clear();

                await FetchCaseFromApi();
            }
            else
            {

                GetCaseBySearch();

            }
        }

        private void ExecuteDisappearingCommand()
        {

            CaseCollections.Clear();

        }



    }
}
