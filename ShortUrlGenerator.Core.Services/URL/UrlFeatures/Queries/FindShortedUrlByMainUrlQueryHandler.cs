using MediatR;
using ShortUrlGenerator.Core.Contracts.Url;
using ShortUrlGenerator.Core.Domains.URL.UrlDomainModel;
using ShortUrlGenerator.Core.Domains.URL.UrlFeatures.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrlGenerator.Core.Services.URL.UrlFeatures.Queries
{
    public class FindShortedUrlByMainUrlQueryHandler : IRequestHandler<FindShortedUrlByMainUrlQueryModel, Url>
    {
        private readonly IUrlRepository _repository;

        public FindShortedUrlByMainUrlQueryHandler(IUrlRepository repository)
        {
            _repository = repository;
        }
        public async Task<Url> Handle(FindShortedUrlByMainUrlQueryModel request, CancellationToken cancellationToken)
        {
            return _repository.FindShortedUrl(request.MainUrl); 
        }
    }
}
