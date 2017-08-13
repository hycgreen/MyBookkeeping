using MyBookkeeping.Models.ViewModel;
using System.Collections.Generic;

namespace MyBookkeeping.Service
{
    public interface IAccountingService
    {
        IEnumerable<JournalListViewModel> Lookup();
    }
}
