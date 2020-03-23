using System.ComponentModel.DataAnnotations;

namespace Persistence_Layer.Models
{
    public class Relationship: Audit
    {
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Description { get; set; }
    }
}