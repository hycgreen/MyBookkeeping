using System;
using System.Collections.Generic;
using MyBookkeeping.Models.ViewModel;
using MyBookkeeping.Repositories;
using X.PagedList;

namespace MyBookkeeping.Service
{
    public class AccountingService : IAccountingService
    {
        private readonly IAccountingRepository _accountingRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountingService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._accountingRepository = new AccountingRepository(unitOfWork);
        }

        public void Delete(Guid id)
        {
            this._accountingRepository.Delete(id);
        }

        public IPagedList<JournalListViewModel> Lookup(int pageNumber, int pageSize)
        {
            var results = this._accountingRepository
                              .LookupAll()
                              .ToPagedList(pageNumber, pageSize);

            return results;
        }

        public JournalViewModel GetSingle(Guid id)
        {
            var result = this._accountingRepository.GetSingle(id);

            return result;
        }

        public void Insert(JournalViewModel fromUI)
        {
            this._accountingRepository.Insert(fromUI);
        }

        public void Save()
        {
            this._unitOfWork.Save();
        }

        public void Update(JournalViewModel fromUI)
        {
            this._accountingRepository.Update(fromUI);
        }

        public ICollection<JournalViewModel> GetFeeds(int rowNumber)
        {
            var results = this._accountingRepository
                              .GetTop(rowNumber);

            return results;
        }
    }
}