
namespace SndAPI.Services
{
    public class OutfitIdUpdateService : BackgroundService
    {
        private readonly PeriodicTimer _timer = new(TimeSpan.FromSeconds(5));
        private readonly IOutfitScrapper _outfitScrapper;

        public OutfitIdUpdateService(IOutfitScrapper outfitScrapper)
        {
            _outfitScrapper = outfitScrapper;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (await _timer.WaitForNextTickAsync(stoppingToken)&& !stoppingToken.IsCancellationRequested){
                await DoWorkAsync();
            }
        }

        private async Task DoWorkAsync(){
           await _outfitScrapper.Scrap();
        }
    }
}