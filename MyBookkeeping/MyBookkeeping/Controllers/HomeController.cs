using MyBookkeeping.BLL;
using MyBookkeeping.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MyBookkeeping.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult List()
        {
            var logic = new AccountingLogic();
            var models = logic.GetJournal();

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