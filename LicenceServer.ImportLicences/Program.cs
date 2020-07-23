using LicenceManager.Core;
using LicenceManager.Persistence;
using LicenceManager.Persistence.Repositories;
using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace LicenceServer.ImportLicences
{
  class Program
  {
    static async Task Main(string[] args)
    {
      using (ApplicationDbContext ctx = new ApplicationDbContext())
      {
        ctx.Database.EnsureCreated();

        ctx.Licences.Add(new Licence() { UserName = "Tenenbot", ValidUntil = new DateTime(2021, 12, 31) });
        ctx.Licences.Add(new Licence() { UserName = "Joe", ValidUntil = new DateTime(2021, 12, 31) });
        ctx.Licences.Add(new Licence() { UserName = "Franz", ValidUntil = new DateTime(2018, 12, 31) });

        await ctx.SaveChangesAsync();

        LicenceRepository licenceRepository = new LicenceRepository(ctx);

        foreach(Licence licence in await licenceRepository.GetCurrentValidLicencesAsync())
        {
          Console.WriteLine(licence);
        }
      }
    }
  }
}
