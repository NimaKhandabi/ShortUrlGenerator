using MediatR;
using ShortUrlGenerator.Core.Contracts.URL;
using ShortUrlGenerator.Core.Domains.URL.UrlDomainModel;
using ShortUrlGenerator.Core.Domains.URL.UrlFeatures.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrlGenerator.Core.Services.URL.UrlFeatures.Command
{
    public class AddUrlCommandHandler : IRequestHandler<AddUrlCommandModel, Url>
    {
        private readonly IUrlRepository _repository;

        public AddUrlCommandHandler(IUrlRepository repository)
        {
            _repository = repository;
        }
        public async Task<Url> Handle(AddUrlCommandModel request, CancellationToken cancellationToken)
        {
            var url = new Url
            {
                MainUrl = request.MainUrl,
                ShortedUrl = ShortUrlGenerator(request.MainUrl)
            };
            _repository.Add(url);
            return url;
        }



        // Refactor //
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
