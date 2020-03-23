using System.ComponentModel.DataAnnotations;

namespace Persistence_Layer.Models
{
    public class TransactionType : Audit
    {
        [Key]
        public int Type { get; set; }
        [MaxLength(255)]
        [Required(ErrorMessage = "Description is Required.")]
        public string Description { get; set; }
        public int Mode { get; set; }
    }
}