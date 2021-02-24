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
  public class StateViewModel : BaseViewModel
    {

        private bool _isrefreshing = false;
        private string _searchBarText;
        public Command AppearingCommand => new Command(ExecuteFetchCases);
        public Command DisappearingCommand => new Command(ExecuteDisappearingCommand);
        public Command SearchButtonPressedCommand => new Command(ExecuteSearchButtonPressedCommand);
        public Command TextChangedCommand => new Command(ExecuteTextChangedCommand);
        public ObservableCollection<StateCase> CaseCollection { get; set; }
 

        public StateViewModel(INavigation Navigation)
        {
            Navigation = navigation;
            CaseCollection = new ObservableCollection<StateCase>();

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






        private async Task FetchCaseFromApi()
        {
            await Task.Delay(2000);
            try
            {
                using (UserDialogs.Instance.Toast("Please Wait..."))
                {

                    CaseCollection.Clear();

                    var url = Links.endpoint;

                    var response = await _httpclient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {

                        var content = response.Content.ReadAsStringAsync().Result;

                        var json = JsonConvert.DeserializeObject<List<StateCase>>(content);


                        var casesFound = new ObservableCollection<StateCase>(json);





                        foreach (var cases in casesFound)
                        {
                            CaseCollection.Add(cases);

                        }

                    }
                }

            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await UserDialogs.Instance.AlertAsync("Something went wrong, try again later.", "Error", "Ok");

            }
        }

        private void ExecuteSearchButtonPressedCommand()
        {
            GetCasesBySearch();
        }

        private async void GetCasesBySearch()
        {
            try
            {
                var keyboard = SearchBarText;

                var url = Links.endpoint;

                var response = await _httpclient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;

                    var json = JsonConvert.DeserializeObject<List<StateCase>>(content);

                   
                    CaseCollection.Clear();

                    var casesFound = new ObservableCollection<StateCase>(json);
                  

                    var searchedCountry = casesFound.Where(c => c.State.ToLower().Contains(SearchBarText.ToLower()));

                    foreach (var country in searchedCountry)
                    {
                        CaseCollection.Add(country);
                    }

                    var searchedCountryCount = new List<StateCase>(searchedCountry).Count;



                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

                await UserDialogs.Instance.AlertAsync("Something went wrong, please try again later.", "Error", "Ok");
            }
        }

        private async void ExecuteTextChangedCommand()
        {
            if (_searchBarText == string.Empty)
            {
               
                CaseCollection.Clear();

                await FetchCaseFromApi();
            }
            else
            {
                GetCasesBySearch();
            }
        }


        private void ExecuteDisappearingCommand()
        {
            CaseCollection.Clear();
        }


    }
}
