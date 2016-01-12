using System.Web.Mvc;


namespace contact_management.web.Controllers
{
  public class HomeController : ApplicationControllerBase
  {
    [AllowAnonymous]
    public ActionResult Index()
    {
      return View();
    }
  }
}