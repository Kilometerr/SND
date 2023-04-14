using SndAPI.Clients;
using SndAPI.Models;
using Newtonsoft.Json;
using SndAPI.Data;

namespace SndAPI.Services
{
    public class OutfitScrapper : IOutfitScrapper
    {
        private readonly IArshaService _arshaService;
        private readonly IBdoApiClient _bdoApiClient;
        private readonly IOutfitRepository _outfitRepository;

        public OutfitScrapper(IArshaService arshaService, IBdoApiClient bdoApiClient, IOutfitRepository outfitRepository)
        {
            _arshaService = arshaService;
            _bdoApiClient = bdoApiClient;
            _outfitRepository = outfitRepository;
        }
        public async Task Scrap()
        {
            var client = _bdoApiClient.GetClientAll();
            var StringJson = await _arshaService.GetAll(client);
            //var ItemList = JsonConvert.DeserializeObject<List<JsonItem>>(StringJson);
            var ItemList = JsonConvert.DeserializeObject<List<JsonItem>>(StringJson);
            var IDs= ScrapOutfitIDs(ItemList);
            System.Console.WriteLine(IDs.Id);
            System.Console.WriteLine(IDs.IdList);
            System.Console.WriteLine(IDs.UpdateDate);
            _outfitRepository.saveIDs(IDs);
        }

        private static OutfitIDs ScrapOutfitIDs(List<JsonItem> jsonItems)
        {
            string IDs = "";
            foreach (var item in jsonItems)
            {
                if (item.Name.Contains("Outfit Set") || item.Name.Contains("Premium Set"))
                {
                    IDs = IDs + item.Id + ",";
                }
            } 

            OutfitIDs oid = new OutfitIDs();
            oid.IdList=IDs.Remove(IDs.Length - 1);
            oid.UpdateDate=DateTime.Now;
            return oid;
        }
    }
}