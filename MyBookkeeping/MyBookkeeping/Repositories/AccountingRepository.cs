using MyBookkeeping.Models;
using MyBookkeeping.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBookkeeping.Repositories
{
    public class AccountingRepository : IAccountingRepository
    {
        private readonly BookkeppingContext _context;

        public AccountingRepository()
        {
            this._context = new BookkeppingContext();
        }

        public void Delete(Guid id)
        {
            var entity = new AccountBook() { Id = id };
            this._context.AccountBook.Attach(entity);
            this._context.AccountBook.Remove(entity);
        }


        public IEnumerable<JournalListViewModel> GetAll()
        {
            var results = this._context.AccountBook
                              .Select(p => new JournalListViewModel()
                              {
                                  Category = p.Categoryyy.ToString(),
                                  Date = p.Dateee,
                                  Amount = p.Amounttt
                              }).ToList();

            return results;
        }

        public JournalViewModel GetSingle(Guid id)
        {
            var result = this._context.AccountBook
                             .Where(p => p.Id == id)
                             .Select(p => new JournalViewModel()
                             {
                                 Id = p.Id,
                                 Category = p.Categoryyy.ToString(),
                                 Date = p.Dateee,
                                 Amount = p.Amounttt,
                                 Remark = p.Remarkkk
                             })
                             .SingleOrDefault();

            return result;
        }

        public void Insert(JournalViewModel fromUI)
        {
            var entity = new AccountBook();
            entity.Id = fromUI.Id;

            int category;
            int.TryParse(fromUI.Category, out category);
            entity.Categoryyy = category;

            entity.Dateee = fromUI.Date;
            entity.Amounttt = decimal.ToInt32(fromUI.Amount);
            entity.Remarkkk = fromUI.Remark;

            this._context.AccountBook.Add(entity);
        }

        public void Save()
        {
            this._context.SaveChanges();
        }

        public void Update(JournalViewModel fromUI)
        {
            var entity = new AccountBook();
            entity.Id = fromUI.Id;

            this._context.AccountBook.Attach(entity);
            int category;
            int.TryParse(fromUI.Category, out category);
            entity.Categoryyy = category;

            entity.Dateee = fromUI.Date;
            entity.Amounttt = decimal.ToInt32(fromUI.Amount);
            entity.Remarkkk = fromUI.Remark;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}