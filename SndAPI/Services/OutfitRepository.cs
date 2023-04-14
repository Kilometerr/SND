using SndAPI.Data;
using SndAPI.Models;

namespace SndAPI.Services
{
    public class OutfitRepository : IOutfitRepository
    {
        private readonly SndDbContext _sndDbContext;

        public OutfitRepository(SndDbContext sndDbContext)
        {
            _sndDbContext = sndDbContext;
        }

        public void saveIDs(OutfitIDs outfitIDs)
        {
            _sndDbContext.Add(outfitIDs);
            _sndDbContext.SaveChanges();
        }
    }
}