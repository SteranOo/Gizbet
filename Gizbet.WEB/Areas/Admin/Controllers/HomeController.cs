using System.Threading.Tasks;
using System.Web.Mvc;

namespace Gizbet.WEB.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}