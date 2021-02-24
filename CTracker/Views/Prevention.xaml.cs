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
    public partial class Prevention : PopupPage
    {
        public Prevention()
        {
            InitializeComponent();

            var prev = new List<Prevantion>()
            {
                new Prevantion {startImg= "usemask", endImg = "wash", startText= "Use Mask", endText ="Wash the hands"},
                new Prevantion {startImg= "usepaper", endImg = "donttouch", startText= "Do not touch \n your mouth and nose".Replace("\n", System.Environment.NewLine), endText ="Avoid touching \n animals".Replace("\n", System.Environment.NewLine)}
            };

            listOfPrevention.ItemsSource = prev;
        }
    }

    public class Prevantion
    {
        public string startImg { get; set; }
        public string endImg { get; set; }
        public string startText { get; set; }
        public string endText { get; set; }
    }
}