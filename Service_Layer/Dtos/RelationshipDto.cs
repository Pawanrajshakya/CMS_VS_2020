using System.ComponentModel.DataAnnotations;

namespace Service_Layer.Dtos
{
    public class RelationshipDto
    {
        [Required]
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}