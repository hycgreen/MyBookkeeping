using System;

namespace MyBookkeeping.Models.ViewModel
{
    public class JournalViewModel
    {
        public Guid Id { get; set; }

        public string Category { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public string Remark { get; set; }
    }
}