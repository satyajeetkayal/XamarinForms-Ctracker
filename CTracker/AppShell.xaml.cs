using CTracker.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CTracker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
           // RegisterRoutes();
        }
       // public static void RegisterRoutes()
       // {
       //     Routing.RegisterRoute("world", typeof(WorldView));
       //     Routing.RegisterRoute("countriesview", typeof(CountriesView));
       //     Routing.RegisterRoute("country", typeof(CountryView));
      //      Routing.RegisterRoute("state", typeof(StateView));
       //     Routing.RegisterRoute("home", typeof(Home));
        //    Routing.RegisterRoute("settings", typeof(Settings));


       // }

    }
}