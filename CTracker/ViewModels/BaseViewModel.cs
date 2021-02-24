using CTracker.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CTracker.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public readonly HttpClient _httpclient;
        public PermissionService _permissionService;
        private bool _isNotConnected { get; set; }
        public INavigation navigation { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        }

        public BaseViewModel()
        {
            _permissionService = new PermissionService();
            _httpclient = new HttpClient();

            Connectivity.ConnectivityChanged += ConnectivityOnConnectivityChanged;
            IsNotConnected = Connectivity.NetworkAccess != NetworkAccess.Internet;



        }

        ~BaseViewModel()
        {
            Connectivity.ConnectivityChanged -= ConnectivityOnConnectivityChanged;
        }


        private void ConnectivityOnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            IsNotConnected = e.NetworkAccess != NetworkAccess.Internet;
        }

        public bool IsNotConnected
        {
            get => _isNotConnected;
            set
            {
                _isNotConnected = value;
                OnPropertyChanged();
            }
        }


    }
}
