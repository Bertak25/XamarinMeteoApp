using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using MeteoApp.ViewModels;

namespace MeteoApp
{
    public partial class MeteoItemPage : ContentPage
    {
        public MeteoItemPage(Entry entry)
        {
            InitializeComponent();
            MeteoHttpRequest.GetWeatherAsync(entry);
            
        }
    }
}