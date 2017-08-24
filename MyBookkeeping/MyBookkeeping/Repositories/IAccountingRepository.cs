using System;
using System.Collections.Generic;
using System.Linq;
using MyBookkeeping.Models.ViewModel;

namespace MyBookkeeping.Repositories
{
    public interface IAccountingRepository
    {
        IUnitOfWork UnitOfWork { get; set; }

        IQueryable<JournalListViewModel> LookupAll();

        JournalViewModel GetSingle(Guid id);

        void Insert(JournalViewModel fromUI);

        void Delete(Guid id);

        void Update(JournalViewModel fromUI);

        void Save();
    }
}