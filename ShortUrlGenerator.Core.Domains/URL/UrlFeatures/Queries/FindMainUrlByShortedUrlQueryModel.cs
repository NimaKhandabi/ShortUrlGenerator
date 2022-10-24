using MediatR;
using ShortUrlGenerator.Core.Domains.URL.UrlDomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrlGenerator.Core.Domains.URL.UrlFeatures.Queries
{
    public class FindMainUrlByShortedUrlQueryModel: IRequest<Url>
    {
        public string ShortedUrl { get; set; }
    }
}
