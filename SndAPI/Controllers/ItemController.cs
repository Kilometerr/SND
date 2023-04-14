using Microsoft.AspNetCore.Mvc;
using SndAPI.Clients;
using SndAPI.Services;

namespace SndAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly IArshaService _arshaService;
        private readonly IBdoApiClient _bdoApiClient;

        public ItemController(IArshaService arshaService, IBdoApiClient bdoApiClient)
        {
            _arshaService = arshaService;
            _bdoApiClient = bdoApiClient;
        }

        //todo add so it gets id from form on site
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            HttpClient client = _bdoApiClient.GetClientList();//replace with database call
            //add business logic to get data for specific item
            var result = await _arshaService.GetById(client, 10006);
            return Ok(result);
        }
    }
}