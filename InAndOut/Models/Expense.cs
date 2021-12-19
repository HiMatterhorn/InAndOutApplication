using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Expense Name")]
        public string ExpenseName { get; set; }
        [Required]
        [DisplayName("Amount of Money")]
        public double AmountOfMoney { get; set; }
    }

}
