using MyBookkeeping.Service;
using System.Web.Mvc;

namespace MyBookkeeping.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAccountingService _accountingService;

        public HomeController()
        {
            _accountingService = new AccountingService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult List()
        {
            var models = _accountingService.Lookup();

            return View(models);
        }

        public ActionResult About()
        {
            ViewBag.Message = "MVC5 Homework";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}