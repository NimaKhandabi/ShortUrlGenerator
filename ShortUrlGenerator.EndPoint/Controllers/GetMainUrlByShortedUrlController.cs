using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShortUrlGenerator.Core.Contracts;
using ShortUrlGenerator.Core.Domains.URL.UrlFeatures.Queries;

namespace ShortUrlGenerator.EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetMainUrlByShortedUrlController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetMainUrlByShortedUrlController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetMainAddressByShortAddress(string shortedAddress)
        {
            var mainUrl = _mediator.Send(new FindMainUrlByShortedUrlQueryModel { ShortedUrl = shortedAddress });
            return Ok(mainUrl);
        }
    }
}
