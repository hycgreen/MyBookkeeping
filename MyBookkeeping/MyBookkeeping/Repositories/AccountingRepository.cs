﻿using MyBookkeeping.Models;
using MyBookkeeping.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MyBookkeeping.Repositories
{
    public class AccountingRepository : IAccountingRepository
    {
        public AccountingRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; set; }

        private DbSet<AccountBook> _accountBook;
        private DbSet<AccountBook> AccountBook
        {
            get
            {
                if (_accountBook == null)
                {
                    _accountBook = UnitOfWork.Context.Set<AccountBook>();
                }
                return _accountBook;
            }
        }

        public void Delete(Guid id)
        {
            var entity = new AccountBook() { Id = id };
            this.AccountBook.Attach(entity);
            this.AccountBook.Remove(entity);
        }

        public IEnumerable<JournalListViewModel> GetAll(int pageIndex, int pageSize)
        {
            var results = this.GetList()
                              .OrderBy(p => p.Date)
                              .Skip(pageIndex * pageSize)
                              .Take(pageSize)
                              .ToList();

            return results;
        }

        private IQueryable<JournalListViewModel> GetList()
        {
            var results = this.AccountBook
                              .Select(p => new JournalListViewModel()
                              {
                                  Category = (p.Categoryyy == 0) ? "支出" : "收入",
                                  Date = p.Dateee,
                                  Amount = p.Amounttt
                              })
                              .AsNoTracking();

            return results;
        }

        public JournalViewModel GetSingle(Guid id)
        {
            var result = this.AccountBook
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

            this.AccountBook.Add(entity);
        }

        public void Save()
        {
            this.UnitOfWork.Save();
        }

        public void Update(JournalViewModel fromUI)
        {
            var entity = new AccountBook();
            entity.Id = fromUI.Id;

            this.AccountBook.Attach(entity);
            int category;
            int.TryParse(fromUI.Category, out category);
            entity.Categoryyy = category;

            entity.Dateee = fromUI.Date;
            entity.Amounttt = decimal.ToInt32(fromUI.Amount);
            entity.Remarkkk = fromUI.Remark;
        }
    }
}