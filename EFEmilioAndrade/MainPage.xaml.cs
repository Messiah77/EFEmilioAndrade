using EFEmilioAndrade.JEAIModels;
using Newtonsoft.Json;
using System.Net;

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
}

