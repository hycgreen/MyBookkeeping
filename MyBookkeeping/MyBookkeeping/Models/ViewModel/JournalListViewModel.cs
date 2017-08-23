using System;
using System.ComponentModel.DataAnnotations;

namespace MyBookkeeping.Models.ViewModel
{
    public class JournalListViewModel
    {
        [Display(Name = "類別")]
        public string Category { get; set; }

        [Display(Name = "日期")]
        public DateTime Date { get; set; }

        [Display(Name = "金額")]
        public decimal Amount { get; set; }
    }
}