using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
//using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace MeteoApp
{
    public partial class MeteoItemPage : ContentPage
    {
        public MeteoItemPage()
        {
            InitializeComponent();

            //GetWeatherAsync();
        }
    }

    //private async Task GetWeatherAsync()
    //{
    //    var httpClient = new HttpClient();
    //    var content = await httpClient.GetStringAsync("https://samples.openweathermap.org/data/2.5/weather?q=London,uk&appid=b6907d289e10d714a6e88b30761fae22");

    //    var weather = (string)JObject.Parse(content)["weather"][0]["main"];

    //    Weather.Text = weather;
    //}
}