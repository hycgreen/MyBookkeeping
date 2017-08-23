using System.ComponentModel.DataAnnotations;

namespace MyBookkeeping.Models
{
    public enum JournalCategory
    {
        [Display(Name = "支出")]
        Expend = 0,
        [Display(Name = "收入")]
        Income = 1
    }
}