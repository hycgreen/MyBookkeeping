using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyBookkeeping.Models.ViewModel
{
    public class JournalViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "類別")]
        [Required]
        public JournalCategory? Category { get; set; }

        [Display(Name = "日期")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [Remote("EarlierThanToday", "Valid", ErrorMessage = "{0} 不得大於今天")]
        [UIHint("Date")]
        public DateTime Date { get; set; }

        [Display(Name = "金額")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "{0} 請輸入正整數")]
        [UIHint("CurrencySpinner")]
        public decimal Amount { get; set; }

        [Display(Name = "備註")]
        [Required]
        [StringLength(100)]
        public string Remark { get; set; }
    }
}