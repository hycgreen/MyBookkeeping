using MyBookkeeping.Models;
using MyBookkeeping.Models.ViewModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyBookkeeping.Service
{
    public class AccountingService : IAccountingService
    {
        private readonly BookkeppingContext _db;

        public AccountingService()
        {
            this._db = new BookkeppingContext();
        }

        public IEnumerable<JournalListViewModel> Lookup()
        {
            var results = this._db.AccountBook
                              .Take(10)
                              .Select(p => new JournalListViewModel()
                              {
                                  Category = p.Categoryyy.ToString(),
                                  Date = p.Dateee,
                                  Amount = p.Amounttt
                              });

            return results;
        }
    }
}