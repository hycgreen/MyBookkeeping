using System;
using System.Collections.Generic;
using MyBookkeeping.Models.ViewModel;
using X.PagedList;

namespace MyBookkeeping.Service
{
    public interface IAccountingService
    {
        IPagedList<JournalListViewModel> Lookup(int pageNumber, int pageSize);

        JournalViewModel GetSingle(Guid id);

        ICollection<JournalViewModel> GetFeeds(int rowNumber);

        void Insert(JournalViewModel fromUI);

        void Delete(Guid id);

        void Update(JournalViewModel fromUI);

        void Save();
    }
}