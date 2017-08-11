using MyBookkeeping.DAL;
using MyBookkeeping.Models.ViewModel;
using System.Collections.Generic;

namespace MyBookkeeping.BLL
{
    public interface IAccountingService
    {
        IAccountingDAL AccountingDAL { get; set; }

        IEnumerable<JournalListViewModel> GetJournal();
    }
}
