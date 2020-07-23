using LicenceManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LicenceManager.Persistence.Repositories
{
  public class LicenceRepository
  {
    private readonly ApplicationDbContext _applicationDbContext;

    public LicenceRepository(ApplicationDbContext applicationDbContext)
    {
      _applicationDbContext = applicationDbContext;
    }

    public async Task<IEnumerable<Licence>> GetCurrentValidLicencesAsync()
      => await _applicationDbContext.Licences
          .Where(l => l.ValidUntil >= DateTime.Now.Date)
          .ToArrayAsync();
  }
}
