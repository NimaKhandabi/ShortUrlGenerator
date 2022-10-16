using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShortUrlGenerator.Core.Contracts;

namespace ShortUrlGenerator.EndPoint.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly IUrlService _urlService;
        public UrlController(IUrlService urlService)
        {
            _urlService = urlService;
        }

        [HttpGet]
        public IActionResult GetShortedAddress(string mainUrl)
        {
            return Ok(_urlService.GetShortedUrl(mainUrl));
        }

        [HttpGet]
        public IActionResult getMainAddressBySHortedUrl(string shortedUrl)
        {
            return Ok(_urlService.GetMainUrlByShortedUrl(shortedUrl));
        }       
    }
}
