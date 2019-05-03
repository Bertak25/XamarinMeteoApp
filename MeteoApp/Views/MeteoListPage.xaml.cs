using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

using Plugin.Geolocator;

namespace MeteoApp
{
    public partial class MeteoListPage : ContentPage
    {
        public Entry entry = new Entry();
        public MeteoListPage()
        {
            InitializeComponent();

            GetLocation();
            
            BindingContext = new MeteoListViewModel(entry);
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        void OnItemAdded(object sender, EventArgs e)
        {
            DisplayAlert("Messaggio", "Testo", "OK");
        }

        void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Navigation.PushAsync(new MeteoItemPage(e.SelectedItem as Entry)
                {
                    BindingContext = e.SelectedItem as Entry
                });
            }
        }

        async void GetLocation()
        {
            var locator = CrossGeolocator.Current; // singleton
            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
            entry.ID = 11;
            entry.Name = "Current";
            entry.Latitude = position.Latitude;
            entry.Longitude = position.Longitude;
        }
    }
}