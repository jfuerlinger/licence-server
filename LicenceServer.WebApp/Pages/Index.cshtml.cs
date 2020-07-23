using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicenceManager.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace LicenceServer.WebApp.Pages
{
  public class IndexModel : PageModel
  {
    public IEnumerable<Licence> Licences { get; set; }

    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
      _logger = logger;
    }



    public async Task<ActionResult> OnGet()
    {
      Licence = await 
    }
  }
}
