//using Microsoft.EntityFrameworkCore;
//using ShortUrlGenerator.Core.Contracts;
//using ShortUrlGenerator.Core.Services;
//using ShortUrlGenerator.Infra.Dal.Sql;

//var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddControllers();
//builder.Services.AddControllersWithViews();


//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


//builder.Services.AddDbContext<ShortUrlGeneratorDbContext>(
//    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Cnn")));


//builder.Services.AddTransient<IUrlService, UrlService>();
//builder.Services.AddTransient<IUrlRepository, UrlRepository>();

//var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();


//app.UseAuthorization();
////
////app.MapDefaultControllerRoute();
////
//app.Run();

using Microsoft.EntityFrameworkCore;
using ShortUrlGenerator.Infra.Dal.Sql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShortUrlGeneratorDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("Cnn")));

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

