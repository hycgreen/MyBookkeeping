﻿using MyBookkeeping.Models.ViewModel;
using System;
using System.Collections.Generic;

namespace MyBookkeeping.Service
{
    public interface IAccountingService
    {
        IEnumerable<JournalListViewModel> GetAll();

        JournalViewModel GetSingle(Guid id);

        void Insert(JournalViewModel fromUI);

        void Delete(Guid id);

        void Update(JournalViewModel fromUI);
    }
}
