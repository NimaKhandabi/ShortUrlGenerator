using MediatR;
using ShortUrlGenerator.Core.Domains.URL.UrlDomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrlGenerator.Core.Domains.URL.UrlFeatures.Commands
{
    public class AddUrlCommandModel: IRequest<Url>
    {
        public string MainUrl { get; set; }
    }
}
