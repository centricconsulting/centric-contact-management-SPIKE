using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;
using contact_management.web.Models;
using Microsoft.AspNet.Identity;
using ActionFilterAttribute = System.Web.Mvc.ActionFilterAttribute;

namespace contact_management.web.Controllers
{
  [RequireHttps]
  [System.Web.Mvc.Authorize]
  public abstract class ApplicationControllerBase : Controller
  {
    protected readonly ApplicationDbContext Db = new ApplicationDbContext();

    protected async Task<List<Guid>> GetUserKnownContacts()
    {
      var userId = User.Identity.GetUserId();
      var user = await Db.Users.Include(c => c.KnownContacts).FirstOrDefaultAsync(c => c.Id == userId);

      return user.KnownContacts.Select(c => c.Id).ToList();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        Db.Dispose();
      }
      base.Dispose(disposing);
    }
  }

  [RequireHttps]
  public abstract class ApplicationApiControllerBase : ApiController
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

  //public class MyActionFilter : ActionFilterAttribute
  //{
  //  public override void OnActionExecuting(HttpActionContext actionContext)
  //  {
  //    if (actionContext.RequestContext.a)

  //    base.OnActionExecuting();
  //  }

  //  //public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
  //  //{
  //  //  //....
  //  //}
  //}
}