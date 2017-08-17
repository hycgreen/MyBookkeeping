using MyBookkeeping.Models.ViewModel;
using MyBookkeeping.Repositories;
using System;
using System.Collections.Generic;

namespace MyBookkeeping.Service
{
    public class AccountingService : IAccountingService
    {
        private readonly IAccountingRepository _accountingRepository;
        
        public AccountingService()
        {
            var unitOfWork = new EFUnitOfWork();
            this._accountingRepository = new AccountingRepository(unitOfWork);
        }

        public void Delete(Guid id)
        {
            this._accountingRepository.Delete(id);
            this._accountingRepository.Save();
        }

        public IEnumerable<JournalListViewModel> GetAll()
        {
            var results = this._accountingRepository.GetAll();

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
            this._accountingRepository.Save();
        }

        public void Update(JournalViewModel fromUI)
        {
            this._accountingRepository.Update(fromUI);
            this._accountingRepository.Save();
        }
    }
}