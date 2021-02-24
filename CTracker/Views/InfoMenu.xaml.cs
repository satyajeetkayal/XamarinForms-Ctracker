using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
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
    public partial class InfoMenu : PopupPage
    {
        public InfoMenu()
        {
            InitializeComponent();
        }


        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new Symtoms());
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new Prevention());
        }

        private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new Symtoms());
        }

        private void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new Prevention());
        }
    }
}