﻿using MyBookkeeping.Models;
using MyBookkeeping.Models.ViewModel;
using System;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

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

        public IQueryable<JournalListViewModel> LookupAll(int? year, int? month)
        {
            var queryable = this.AccountBook.AsQueryable();

            if (year != null)
            {
                queryable = queryable.Where(x => x.Dateee.Year == year);
            }

            if (month != null)
            {
                queryable = queryable.Where(x => x.Dateee.Month == month);
            }

            var results = queryable.OrderByDescending(p => p.Dateee)
                                   .Select(p => new JournalListViewModel()
                                   {
                                       Id = p.Id,
                                       Category = (JournalCategory) p.Categoryyy,
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
                                 Category = (JournalCategory)p.Categoryyy,
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
            entity.Categoryyy = (int)fromUI.Category;
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

            entity.Categoryyy = (int)fromUI.Category;
            entity.Dateee = fromUI.Date;
            entity.Amounttt = decimal.ToInt32(fromUI.Amount);
            entity.Remarkkk = fromUI.Remark;
        }

        public ICollection<JournalViewModel> GetTop(int rowNumber)
        {
            var results = this.AccountBook
                              .OrderByDescending(p => p.Dateee)
                              .Take(rowNumber)
                              .Select(p => new JournalViewModel()
                              {
                                  Id = p.Id,
                                  Category = (JournalCategory)p.Categoryyy,
                                  Date = p.Dateee,
                                  Amount = p.Amounttt,
                                  Remark = p.Remarkkk
                              })
                              .AsNoTracking()
                              .ToList();

            return results;
        }
    }
}