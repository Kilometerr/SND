using System.Net.Http;

namespace SndAPI.Clients
{
    public class ArshaService : IArshaService
    {
        public async Task<String> GetById(HttpClient httpClient, int id)
        {
            using HttpResponseMessage response = await httpClient.GetAsync($"?ids={id}");

            response.EnsureSuccessStatusCode()
        .WriteRequestToConsole();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            return $"{jsonResponse}";
        }

    }
}