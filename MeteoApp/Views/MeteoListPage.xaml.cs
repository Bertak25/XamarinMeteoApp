using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
using MeteoApp.Views;
using Acr.UserDialogs;

//using Plugin.Geolocator;

namespace MeteoApp
{
    public partial class MeteoListPage : ContentPage
    {
        public Entry entry = new Entry();

        public MeteoListPage()
        {
            InitializeComponent();

            //GetLocation();
            
            BindingContext = new MeteoListViewModel(entry);

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        
        private async void OnItemAdded(object sender, EventArgs e)
        {
            //DisplayAlert("Messaggio", "Testo", "OK");
            //DisplayAlert(await InputBox(this.Navigation).Result, "test", "ok");

            // string result = await InputBox(this.Navigation);


            //await PopupNavigation.PushAsync(new InsertCity());

            var pResult = await UserDialogs.Instance.PromptAsync(new PromptConfig
            {
                InputType = InputType.Name,
                OkText = "Create",
                Title = "Add new city"
            });


            if (pResult.Ok && !string.IsNullOrWhiteSpace(pResult.Text))
            {
                //await DisplayAlert("CIAO", "test", "ok");
                await App.DatabaseManager.SaveCity(new Entry {
                    Name = pResult.Text,
                    //ID = 0,
                    Latitude = 0.0,
                    Longitude = 0.0
                });
            }

            List<Entry> cities = App.DatabaseManager.GetAllCities().Result;

            BindingContext = new MeteoListViewModel(entry);

        }


        //apri altra pagina
        void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Navigation.PushAsync(new MeteoItemPage()
                {
                    BindingContext = e.SelectedItem as Entry
                });
            }
        }

        //async void GetLocation()
        //{
        //    var locator = CrossGeolocator.Current; // singleton
        //    var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
        //    entry.ID = 11;
        //    entry.Name = "Current";
        //    entry.Latitude = position.Latitude;
        //    entry.Longitude = position.Longitude;
        //}
    }
}