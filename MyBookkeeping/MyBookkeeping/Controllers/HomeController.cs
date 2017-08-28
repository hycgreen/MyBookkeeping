using MyBookkeeping.Models.ViewModel;
using MyBookkeeping.Repositories;
using MyBookkeeping.Service;
using System.Web.Mvc;
using MyBookkeeping.filter;

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
                this._accountingService.Insert(data);
                this._accountingService.Save();

                return RedirectToAction("AjaxList");
            }

            return View(data);
        }

        [AjaxOnly]
        public ActionResult AjaxList()
        {
            var list = this._accountingService
                           .Lookup(1, this._pageSize);

            return PartialView("List", list);
        }

        [ChildActionOnly]
        public ActionResult List(int? page)
        {
            if (page.HasValue && page < 1)
                return HttpNotFound();

            var list = this._accountingService
                           .Lookup(page ?? 1, this._pageSize);

            if (list.PageNumber != 1 && page.HasValue && page > list.PageCount)
                return HttpNotFound();

            return View(list);
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