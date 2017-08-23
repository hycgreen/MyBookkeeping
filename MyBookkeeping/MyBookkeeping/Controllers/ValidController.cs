using System;
using System.Web.Mvc;

namespace MyBookkeeping.Controllers
{
    public class ValidController : Controller
    {
        public ActionResult EarlierThanToday(DateTime date)
        {
            bool isValidate = DateTime.Compare(date, DateTime.Today) <= 0;
            return Json(isValidate, JsonRequestBehavior.AllowGet);
        }
    }
}