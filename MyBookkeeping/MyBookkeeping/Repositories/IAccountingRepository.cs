using System;
using System.Collections.Generic;
using MyBookkeeping.Models.ViewModel;

namespace MyBookkeeping.Repositories
{
    public interface IAccountingRepository : IDisposable
    {
        IEnumerable<JournalListViewModel> GetAll();

        JournalViewModel GetSingle(Guid id);

        void Insert(JournalViewModel fromUI);

        void Delete(Guid id);

        void Update(JournalViewModel fromUI);

        void Save();
    }
}