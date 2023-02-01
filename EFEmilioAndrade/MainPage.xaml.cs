using EFEmilioAndrade.JEAIModels;
using Newtonsoft.Json;
using System.Net;
using System.Reflection;

namespace EFEmilioAndrade;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    public async void Button_Clicked(object sender, EventArgs e)
    {
        var request = new HttpRequestMessage();
        request.RequestUri = new Uri("https://api.wheretheiss.at/v1/satellites");
        request.Method = HttpMethod.Get;
        request.Headers.Add("Accept", "application/json");
        var client = new HttpClient();
        HttpResponseMessage response = await client.SendAsync(request);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            String content = await response.Content.ReadAsStringAsync();
            var resultado = JsonConvert.DeserializeObject<List<Satelite>>(content);
            ListaISSJEAI.ItemsSource = resultado;
        }
    }

    private async void SateliteChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            var satelite = (JEAIModels.Satelite)e.CurrentSelection[0];

            string action = await DisplayActionSheet("Escoja una opción:", "Modificar", "Eliminar");

            if (action == "Modificar")
            {
                //await Shell.Current.GoToAsync($"{nameof(Id)}={satelite.id}");
            }
            else if (action == "Eliminar")
            {
                //App.SateliteRepo.DeleteSatelite(satelite);
            }
            else
            {
                //LoadData();
            }

        }
    }
}

