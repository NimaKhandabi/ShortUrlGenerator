using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrlGenerator.Core.Contracts
{
    public interface IUrlService
    {
        string GetShortedUrl(string mainUrl);
        string GetMainUrlByShortedUrl(string shortedUrl);
    }
}
