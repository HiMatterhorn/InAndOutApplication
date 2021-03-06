using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InAndOut.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Borrower { get; set; }
        public string Lender { get; set; }
        [Required]
        [DisplayName("Item name")]
        public string ItemName { get; set; }


    }
}
