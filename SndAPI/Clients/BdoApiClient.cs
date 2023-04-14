namespace SndAPI.Clients
{
    public class BdoApiClient: IBdoApiClient
    {
        public HttpClient GetClientList()
        {
            HttpClient BdoApiSearchListClient = new()
            {
                BaseAddress = new Uri("https://api.arsha.io/v2/eu/GetWorldMarketSearchList"),
            };

            return BdoApiSearchListClient;
        }


    }
}