using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrlGenerator.Core.Domains.URL.UrlDomainModel
{
    public class Url
    {
        public int Id { get; set; }
        public string MainUrl { get; set; }
        public string ShortedUrl { get; set; }
    }
}
