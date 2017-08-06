using System;

namespace MyBookkeeping.Models.ViewModel
{
    public class JournalListViewModel
    {
        public string Category { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }
    }
}