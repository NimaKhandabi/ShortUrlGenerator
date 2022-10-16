using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortUrlGenerator.Infra.Dal.Sql
{
    public class ShortUrlGeneratorDbContextFactory : IDesignTimeDbContextFactory<ShortUrlGeneratorDbContext>
    {
        ShortUrlGeneratorDbContext IDesignTimeDbContextFactory<ShortUrlGeneratorDbContext>.CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<ShortUrlGeneratorDbContext>();
            optionBuilder.UseSqlServer("server=.; Database=ShortUrlGenerator; Trusted_connection=true;");
            return new ShortUrlGeneratorDbContext(optionBuilder.Options);
        }
    }
}
