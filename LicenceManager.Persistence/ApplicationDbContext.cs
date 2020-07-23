using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using LicenceManager.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LicenceManager.Persistence
{
  public class ApplicationDbContext : DbContext
  {

    public DbSet<Licence> Licences { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(Environment.CurrentDirectory)
          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
          .AddEnvironmentVariables();

      var configuration = builder.Build();
      Debug.Write(configuration.ToString());
      string connectionString = configuration["ConnectionStrings:DefaultConnection"];
      optionsBuilder.UseSqlServer(connectionString);

    }
  }
}
