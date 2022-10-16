using ShortUrlGenerator.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrlGenerator.Core.Contracts
{
    public interface IUrlRepository
    {
        Url FindShortedUrl(string mainUrl);
        Url FindMainUrlbyShortedUrl(string shortedUrl);
        void Add(Url url);
    }
}
