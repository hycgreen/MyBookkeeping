using MyBookkeeping.Service;
using System.Web.Mvc;
using MyBookkeeping.Models.ViewModel;
using MyBookkeeping.Repositories;

namespace MyBookkeeping.Controllers
{
    public class HomeController : Controller
    {
        private readonly int _pageSize = 10;
        private readonly IAccountingService _accountingService;

        public HomeController()
        {
            var unitOfWork = new EFUnitOfWork();
            _accountingService = new AccountingService(unitOfWork);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(JournalViewModel data)
        {
            if (this.ModelState.IsValid)
            {
                return View();
            }

            return View(data);
        }

        [ChildActionOnly]
        public ActionResult List(int pageIndex = 1)
        {
            var models = _accountingService.GetAll(pageIndex, this._pageSize);

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