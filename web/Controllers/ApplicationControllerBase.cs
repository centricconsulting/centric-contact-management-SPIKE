using System.Web.Mvc;
using contact_management.web.Models;

namespace contact_management.web.Controllers
{
  [RequireHttps]
  [Authorize]
  public abstract class ApplicationControllerBase : Controller
  {
    protected readonly ApplicationDbContext Db = new ApplicationDbContext();

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        Db.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}