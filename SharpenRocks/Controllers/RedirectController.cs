using System.Web.Mvc;

namespace SharpenRocks.Controllers
{
    public class RedirectController : Controller
    {
        public ActionResult Index()
        {
	        return Redirect("https://github.com/ironcev/Sharpen");
        }
    }
}