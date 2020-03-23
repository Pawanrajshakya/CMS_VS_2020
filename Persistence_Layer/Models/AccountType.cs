using System.ComponentModel.DataAnnotations;

namespace Persistence_Layer.Models
{
    public class AccountType: Audit
    {
        [Key]        
        public int TypeId { get; set; }
        public string Description { get; set; }
    }
}