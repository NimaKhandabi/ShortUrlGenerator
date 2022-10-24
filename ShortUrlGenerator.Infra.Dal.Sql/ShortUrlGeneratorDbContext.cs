using Microsoft.EntityFrameworkCore;
using ShortUrlGenerator.Core.Domains.URL.UrlDomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrlGenerator.Infra.Dal.Sql
{
    public class ShortUrlGeneratorDbContext : DbContext
    {
        public DbSet<Url> Urls { get; set; }
        public ShortUrlGeneratorDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
