using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MeteoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsertCity : ContentPage
    {
        public InsertCity()
        {
            InitializeComponent();
        }

        private async void Click(object sender, EventArgs e)
        {
           // await PopupNavigation.PopAsync(true);
        }
    }
}