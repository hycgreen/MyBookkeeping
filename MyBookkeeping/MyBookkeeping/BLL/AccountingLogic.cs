using MyBookkeeping.DAL;
using MyBookkeeping.Models.ViewModel;
using System.Collections.Generic;

namespace MyBookkeeping.BLL
{
    public class AccountingLogic : IAccountingLogic
    {
        private IAccountingDAL _accountingDAL;

        public AccountingLogic()
        {
        }

        public IAccountingDAL AccountingDAL
        {
            get
            {
                if (_accountingDAL == null)
                {
                    _accountingDAL = new AccountingDAL();
                }

                return this._accountingDAL;
            }
            set { this._accountingDAL = value; }
        }

        public IEnumerable<JournalListViewModel> GetJournal()
        {
            return this.AccountingDAL.GetJournal();
        }
    }
}