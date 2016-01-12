using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace contact_management.web.Controllers
{
  public class AdminController : ApplicationControllerBase
  {
    public async Task<ActionResult> Index() {

      var model = await Db.Users.ToListAsync();

      return View("UserList", model);
    }
  }
}