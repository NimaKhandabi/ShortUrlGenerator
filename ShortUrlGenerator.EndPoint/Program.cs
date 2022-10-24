using MediatR;
using Microsoft.EntityFrameworkCore;
using ShortUrlGenerator.Core.Contracts;
using ShortUrlGenerator.Core.Contracts.Url;
using ShortUrlGenerator.Core.Services.URL.Services;
using ShortUrlGenerator.Core.Services.URL.UrlFeatures.Command;
using ShortUrlGenerator.Core.Services.URL.UrlFeatures.Queries;
using ShortUrlGenerator.Infra.Dal.Sql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//
builder.Services.AddTransient<IUrlService,UrlService>();
builder.Services.AddTransient<IUrlRepository,UrlRepository>();

builder.Services.AddDbContext<ShortUrlGeneratorDbContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("Cnn")));
//
builder.Services.AddMediatR(
    typeof(AddUrlCommandHandler).Assembly,
    typeof(FindShortedUrlByMainUrlQueryHandler).Assembly,
    typeof(FindMainUrlByShortedUrlQueryHandler).Assembly
    );
//

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
