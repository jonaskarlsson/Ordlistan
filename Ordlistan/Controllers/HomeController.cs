using System.Web.Mvc;
using Ordlistan.Models;

namespace Ordlistan.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your quintessential app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your quintessential contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult HittaGutnisktUppslagsord(string searchText, int maxResults)
        {
            GutnisktUppslagsordRepository repository = new GutnisktUppslagsordRepository();
            var result = repository.HittaGutnisktUppslagsord(searchText, maxResults);
            return Json(result);
        }

        [HttpPost]
        public JsonResult HittaSvenskBetydelse(string searchText, int maxResults)
        {
            SvenskBetydelseRepository repository = new SvenskBetydelseRepository();
            var result = repository.HittaSvenskBetydelse(searchText, maxResults);
            return Json(result);
        }
    }
}
