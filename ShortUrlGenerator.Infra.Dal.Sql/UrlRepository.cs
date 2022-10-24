using ShortUrlGenerator.Core.Contracts.URL;
using ShortUrlGenerator.Core.Domains.URL.UrlDomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrlGenerator.Infra.Dal.Sql
{
    public class UrlRepository : IUrlRepository
    {
        private readonly ShortUrlGeneratorDbContext _shortUrlGeneratorDbContext;

        public UrlRepository(ShortUrlGeneratorDbContext shortUrlGeneratorDbContext)
        {
            _shortUrlGeneratorDbContext = shortUrlGeneratorDbContext;
        }
        public void Add(Url url)
        {
            _shortUrlGeneratorDbContext.Add(url);
            _shortUrlGeneratorDbContext.SaveChanges();
        }

        public Url FindMainUrlbyShortedUrl(string shortedUrl)
        {
            return _shortUrlGeneratorDbContext.Urls.SingleOrDefault(c => c.ShortedUrl == shortedUrl);
        }

        public Url FindShortedUrl(string mainUrl)
        {
            return _shortUrlGeneratorDbContext.Urls.SingleOrDefault(c => c.MainUrl == mainUrl);
        }
    }
}
