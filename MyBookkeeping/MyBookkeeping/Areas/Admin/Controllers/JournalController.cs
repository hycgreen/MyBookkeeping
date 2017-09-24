using MyBookkeeping.filter;
using MyBookkeeping.Models.ViewModel;
using MyBookkeeping.Repositories;
using MyBookkeeping.Service;
using System;
using System.Net;
using System.Web.Mvc;

namespace MyBookkeeping.Areas.Admin.Controllers
{
    [AuthorizePlus]
    public class JournalController : Controller
    {
        private readonly int _pageSize = 10;
        private readonly IAccountingService _accountingService;

        public JournalController()
        {
            var unitOfWork = new EFUnitOfWork();
            _accountingService = new AccountingService(unitOfWork);
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = this._accountingService
                            .GetSingle(id.Value);

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [ChildActionOnly]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Category,Date,Amount,Remark")] JournalViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Id = Guid.NewGuid();
                this._accountingService.Insert(model);
                this._accountingService.Save();
            }

            return View(model);
        }

        [AjaxOnly]
        public ActionResult AjaxList()
        {
            var list = this._accountingService
                           .Lookup(1, this._pageSize);

            return PartialView("List", list);
        }

        [ChildActionOnly]
        [AllowAnonymous]
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

        [AuthorizePlus(Roles = "admin")]
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = this._accountingService
                            .GetSingle(id.Value);

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Category,Date,Amount,Remark")] JournalViewModel model)
        {
            if (ModelState.IsValid)
            {
                this._accountingService.Update(model);
                this._accountingService.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [AuthorizePlus(Roles = "admin")]
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = this._accountingService
                            .GetSingle(id.Value);

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            this._accountingService.Delete(id);
            this._accountingService.Save();
            return RedirectToAction("Index");
        }
    }
}
