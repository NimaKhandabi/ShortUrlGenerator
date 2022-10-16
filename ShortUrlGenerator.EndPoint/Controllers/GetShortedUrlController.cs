using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShortUrlGenerator.Core.Contracts;

namespace ShortUrlGenerator.EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetShortedUrlController : ControllerBase
    {
        private readonly IUrlService _urlService;

        public GetShortedUrlController(IUrlService urlService)
        {
            _urlService = urlService;
        }

        [HttpGet]
        public IActionResult GetShortedAddress(string mainUrl)
        {
            return Ok(_urlService.GetShortedUrl(mainUrl));
        }
    }
}
