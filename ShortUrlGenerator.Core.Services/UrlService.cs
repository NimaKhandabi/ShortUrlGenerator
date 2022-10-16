using ShortUrlGenerator.Core.Contracts;
using ShortUrlGenerator.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrlGenerator.Core.Services
{
    public class UrlService : IUrlService
    {
        private readonly IUrlRepository _urlRepository;

        public UrlService(IUrlRepository urlRepository)
        {
            _urlRepository = urlRepository;
        }
        public string GetShortedUrl(string mainUrl)
        {
            var urlInDb = _urlRepository.FindShortedUrl(mainUrl);
            if (urlInDb != null)
            {
                return urlInDb.ShortedUrl;
            }
            else
            {
                var shortedUrl = ShortUrlGenerator(mainUrl);
                var model = new Url
                {
                    MainUrl = mainUrl,
                    ShortedUrl = shortedUrl
                };
                _urlRepository.Add(model);             
                return shortedUrl;
            }
        }
        public string GetMainUrlByShortedUrl(string shortedUrl)
        {
            var urlInDb = _urlRepository.FindMainUrlbyShortedUrl(shortedUrl);
            if (urlInDb != null)
            {
                return urlInDb.MainUrl;
            }
            else
            {
                return "There is No Url!";
            }
        }
        // Can Be Extention Methods
        private string ShortUrlGenerator(string mainUrl)
        {
            Uri uri = new Uri(mainUrl);
            var host = uri.Host;
            var shortedUrl = $"https://{host}/{RandomString()}";
            return shortedUrl;
        }
        private string RandomString(int length = 10)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
