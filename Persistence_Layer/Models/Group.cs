using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Persistence_Layer.Models
{
    public class Group
    {
        [Key]
        public int GroupId { get; set; }

        [Required]
        public string Description { get; set; }

        public List<AccountType> AccountTypes { get; set; }

        public int Order { get; set; }

    }
}