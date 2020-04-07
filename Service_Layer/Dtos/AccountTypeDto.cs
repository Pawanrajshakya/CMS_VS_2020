using System.ComponentModel.DataAnnotations;

namespace Service_Layer.Dtos
{
    public class AccountTypeDto
    {
        [Required(ErrorMessage="Description is required.")]
        public string Description { get; set; }
        public int Order { get; set; }
        public bool IsActive { get; set; }
    }
}