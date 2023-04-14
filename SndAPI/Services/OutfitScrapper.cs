using SndAPI.Clients;
using SndAPI.Models;
using Newtonsoft.Json;

namespace SndAPI.Services
{
    public class OutfitScrapper : IOutfitScrapper
    {
        private readonly IArshaService _arshaService;
        private readonly IBdoApiClient _bdoApiClient;

        public OutfitScrapper(IArshaService arshaService, IBdoApiClient bdoApiClient)
        {
            _arshaService = arshaService;
            _bdoApiClient = bdoApiClient;
        }
        public async Task Scrap()
        {
            var client = _bdoApiClient.GetClientAll();
            var StringJson = await _arshaService.GetAll(client);
            //var ItemList = JsonConvert.DeserializeObject<List<JsonItem>>(StringJson);
            var ItemList = JsonConvert.DeserializeObject<List<JsonItem>>(StringJson);
        }

        
    }
}