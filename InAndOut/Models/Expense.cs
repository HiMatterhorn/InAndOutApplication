using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InAndOut.Models
{
    [Index(nameof(ExpenseTypeId), IsUnique = false)]
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Expense Name")]
        public string ExpenseName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0!")]
        [DisplayName("Amount of Money")]
        public double AmountOfMoney { get; set; }


        [DisplayName("Expense Type")]

        public int ExpenseTypeId { get; set; }

        [ForeignKey("ExpenseTypeId")]
        public virtual ExpenseType ExpenseType { get; set; }
    }

}
