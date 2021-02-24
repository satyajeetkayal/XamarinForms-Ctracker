using CTracker.ViewModels;
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
    public partial class StateView : ContentPage
    {
        public StateView()
        {
            InitializeComponent();

            BindingContext = new StateViewModel(Navigation);
        }

        private void ListviewData_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            ListviewData.SelectedItem = null;


        }
    }
}