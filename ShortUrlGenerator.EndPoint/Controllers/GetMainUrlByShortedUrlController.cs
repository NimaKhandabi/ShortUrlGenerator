using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShortUrlGenerator.Core.Contracts;

namespace ShortUrlGenerator.EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetMainUrlByShortedUrlController : ControllerBase
    {
        private readonly IUrlService _urlService;

        public GetMainUrlByShortedUrlController(IUrlService urlService)
        {
            _urlService = urlService;
        }
        [HttpGet]
        public IActionResult GetMainAddressByShortAddress(string shortedAddress)
        {
            return Ok(_urlService.GetMainUrlByShortedUrl(shortedAddress));
        }
    }
}
