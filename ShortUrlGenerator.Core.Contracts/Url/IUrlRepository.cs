using ShortUrlGenerator.Core.Domains.URL.UrlDomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrlGenerator.Core.Contracts.URL
{
    public interface IUrlRepository
    {
        Url FindShortedUrl(string mainUrl);
        Url FindMainUrlbyShortedUrl(string shortedUrl);
        void Add(Url url);
    }
}
