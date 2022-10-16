// See https://aka.ms/new-console-template for more information
using ShortUrlGenerator.Core.Contracts;
using ShortUrlGenerator.Core.Services;

Console.WriteLine("Hello, World!");



Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Use This Format: http://www.---");
Console.ResetColor();



while (true)
{
    IUrlRepository urlRepository;
    UrlService urlService = new UrlService();
    var str = urlService.GetShortedUrl(Console.ReadLine());

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine(str);
    Console.ResetColor();
}
