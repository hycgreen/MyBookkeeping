using MyBookkeeping.CustomResults;
using MyBookkeeping.Repositories;
using MyBookkeeping.Service;
using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Web.Mvc;
using MyBookkeeping.Helper;

namespace MyBookkeeping.Controllers
{
    public class FeedsController : Controller
    {
        private readonly IAccountingService _accountingService;
        private readonly int _feedSize = 50;

        public FeedsController()
        {
            var unitOfWork = new EFUnitOfWork();
            _accountingService = new AccountingService(unitOfWork);
        }

        // GET: Orders
        public ActionResult Index()
        {
            var feed = this.GetFeedData();
            return new RssResult(feed);
        }

        private SyndicationFeed GetFeedData()
        {
            var feed = new SyndicationFeed(
                                           "我的記帳本",
                                           "收支記錄RSS！",
                                           new Uri(Url.Action("Index", "Feeds", null, "http")));

            var items = new List<SyndicationItem>();

            var accountBooks = this._accountingService
                                   .GetFeeds(this._feedSize);

            foreach (var accountBook in accountBooks)
            {
                var item = new SyndicationItem(
                                               $"{accountBook.Date:yyyy-MM-dd} {accountBook.Category.GetDisplayName()}",
                                               accountBook.Remark,
                                               new Uri(Url.Action("Details", "Journal", new { area = "Admin", id = accountBook.Id }, "http")),
                                               "ID",
                                               DateTime.Now);

                items.Add(item);
            }

            feed.Items = items;
            return feed;
        }
    }
}