using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence_Layer.Models
{
    public class Business : Audit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address1 is required")]
        [MaxLength(255)]
        public string Address1 { get; set; }
        [Required(ErrorMessage = "Address2 is required")]
        [MaxLength(255)]
        public string Address2 { get; set; }
        [Required(ErrorMessage = "State is required")]
        [MaxLength(2)]
        public string State { get; set; }
        [Required(ErrorMessage = "ZipCode is required")]
        [MaxLength(5)]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [MaxLength(255)]
        public string Description { get; set; }
    }
}