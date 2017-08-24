using MyBookkeeping.Models.ViewModel;
using System;
using X.PagedList;

namespace MyBookkeeping.Service
{
    public interface IAccountingService
    {
        IPagedList<JournalListViewModel> Lookup(int pageNumber, int pageSize);

        JournalViewModel GetSingle(Guid id);

        void Insert(JournalViewModel fromUI);

        void Delete(Guid id);

        void Update(JournalViewModel fromUI);

        void Save();
    }
}
