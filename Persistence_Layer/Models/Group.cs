using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Persistence_Layer.Models
{
    public class Group : Audit
    {
        [Required]
        public string Description { get; set; }

        public List<AccountType> AccountTypes { get; set; }

        public int Order { get; set; }

    }
}