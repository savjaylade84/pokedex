using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinWorkshop2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private HttpClient httpClient;
       string baseUrl = "https:/pokeapi.co/api/v2/pokemon";
        public MainPage()
        {
            InitializeComponent();
            httpClient = new HttpClient();
        }

        private async Task Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pokemonEntry.Text))
                return;

            var result = await httpClient.GetStringAsync(baseUrl + pokemonEntry.Text);

            if (result == null)
            {

                await DisplayAlert("pokemon not found");
                return;

            }

            Pokemon pokemon = Newtonsoft.Json.JsonConvert.DeserializeObject<Pokemon>(result);
            pokemonImage.Source = pokemon.sprites.front_default;
           
        }
    }
}
