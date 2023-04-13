
using System.Net.Http;
namespace SndAPI.Clients
{
    public class BdoApiClient
    {
        public static HttpClient getClient()
        {
            HttpClient BdoApiSearchListClient = new()
            {
                BaseAddress = new Uri("https://api.arsha.io/v2/eu/GetWorldMarketSearchList"),
            };

            return BdoApiSearchListClient;
        }


        public static async Task GetById(HttpClient httpClient, int id)
        {
            using HttpResponseMessage response = await httpClient.GetAsync($"?ids={id}");

            response.EnsureSuccessStatusCode()
        .WriteRequestToConsole();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            System.Console.WriteLine($"{jsonResponse}\n");
        }
    }
}