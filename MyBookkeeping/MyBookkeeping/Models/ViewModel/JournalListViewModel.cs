using System;
using System.ComponentModel.DataAnnotations;

namespace MyBookkeeping.Models.ViewModel
{
    public class JournalListViewModel
    {
        [Display(Name = "類別")]
        public JournalCategory Category { get; set; }

        [Display(Name = "日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }

        [Display(Name = "金額")]
        [DisplayFormat(DataFormatString = "{0:#,#}")]
        public decimal Amount { get; set; }
    }
}