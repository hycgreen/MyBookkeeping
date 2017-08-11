using MyBookkeeping.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBookkeeping.DAL
{
    internal class AccountingDAL : IAccountingDAL
    {
        public IEnumerable<JournalListViewModel> GetJournal()
        {
            var results = from data in GenerateFakedata()
                          orderby data.Date ascending
                          select data;

            return results;
        }

        private IEnumerable<JournalListViewModel> GenerateFakedata()
        {
            var results = new List<JournalListViewModel>();

            for (int i = 1; i <= 12; i++)
            {
                var item = new JournalListViewModel()
                {
                    Category = (i % 3 == 0) ? "支出" : "收入",
                    Date = DateTime.Today.AddDays(-i),
                    Amount = i * 100
                };

                results.Add(item);
            }

            return results;
        }
    }
}