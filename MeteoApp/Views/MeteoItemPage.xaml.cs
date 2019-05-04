using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;
using System;
using System.Net;

namespace MeteoApp
{
    public partial class MeteoItemPage : ContentPage
    {
        public MeteoItemPage(Entry entry)
        {
            InitializeComponent();
            BindingContext = entry;
           // GetWeatherAsync(entry);
            
        }

        public async static Task<MeteoItemPage> createMeteoItemPage(Entry entry)
        {
            MeteoItemPage page = new MeteoItemPage(entry);
            await page.GetWeatherAsync(entry);


            return page;
        }

        private async Task GetWeatherAsync(Entry entry)
        {
            var httpClient = new HttpClient();
            var builder = new UriBuilder("https://api.openweathermap.org/data/2.5/weather?");
            builder.Port = -1;
            string postString = String.Format("lat={0}&lon={1}&units={2}&APPID={3}",
            WebUtility.UrlEncode(entry.Latitude.ToString()),
            WebUtility.UrlEncode(entry.Longitude.ToString()),
            WebUtility.UrlEncode("metric"),
            WebUtility.UrlEncode("d9927f346fc26a1925e207acf647f307"));
            string url = builder.ToString() + postString;

            var content = await httpClient.GetStringAsync(url);

            entry.Weather = (string)JObject.Parse(content)["weather"][0]["main"];
            entry.Temp = (double)JObject.Parse(content)["main"]["temp"];
            entry.Humidity = (double)JObject.Parse(content)["main"]["humidity"];
            entry.TempMin = (double)JObject.Parse(content)["main"]["temp_min"];
            entry.TempMax = (double)JObject.Parse(content)["main"]["temp_max"];
            entry.WindSpeed = (double)JObject.Parse(content)["wind"]["speed"];
        }
    }
}