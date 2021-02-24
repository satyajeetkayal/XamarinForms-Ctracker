﻿using CTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountryView : ContentPage
    {
        public CountryView()
        {
            InitializeComponent();
            BindingContext = new CountryViewModel(Navigation);
        }
    }
}