using MyBookkeeping.DAL;
using MyBookkeeping.Models.ViewModel;
using System.Collections.Generic;

namespace MyBookkeeping.BLL
{
    public class AccountingService : IAccountingService
    {
        private IAccountingDAL _accountingDAL;

        public AccountingService()
        {
            this._accountingDAL = new AccountingDAL();
        }

        public IAccountingDAL AccountingDAL
        {
            get { return this._accountingDAL; }
            set { this._accountingDAL = value; }
        }

        public IEnumerable<JournalListViewModel> GetJournal()
        {
            return this.AccountingDAL.GetJournal();
        }
    }
}