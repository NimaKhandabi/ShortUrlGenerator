using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShortUrlGenerator.Core.Contracts;
using ShortUrlGenerator.Core.Domains.URL.UrlFeatures.Commands;
using ShortUrlGenerator.Core.Domains.URL.UrlFeatures.Queries;

namespace ShortUrlGenerator.EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetShortedUrlController : ControllerBase
    {
        private readonly IMediator _mediator;

        //private readonly IUrlService _urlService;

        //public GetShortedUrlController(IUrlService urlService)
        //{
        //    _urlService = urlService;
        //}


        public GetShortedUrlController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetShortedAddress(string mainUrl)
        {
            //return Ok(await _mediator.Send(new FindByUrlQueryModel { MainUrl = mainUrl }));
            var shortedUrl = _mediator.Send(new FindShortedUrlByMainUrlQueryModel { MainUrl = mainUrl });
            if (shortedUrl.Result == null)
            {
                shortedUrl = _mediator.Send(new AddUrlCommandModel { MainUrl = mainUrl });
            }
            return Ok(shortedUrl);
        }
    }
}
