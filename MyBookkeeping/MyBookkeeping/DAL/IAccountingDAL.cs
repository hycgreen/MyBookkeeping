using MyBookkeeping.Models.ViewModel;
using System.Collections.Generic;

namespace MyBookkeeping.DAL
{
    public interface IAccountingDAL
    {
        IEnumerable<JournalListViewModel> GetJournal();
    }
}