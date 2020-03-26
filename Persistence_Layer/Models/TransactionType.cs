using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence_Layer.Models
{
    public class TransactionType : Audit
    {
        [Key]
        public int TranType { get; set; }
        [MaxLength(255)]
        [Required(ErrorMessage = "Description is Required.")]
        public string Description { get; set; }
        [ForeignKey("AccountNo")]
        public Account Account { get; set; }
        public int AccountNo { get; set; }
    }
}