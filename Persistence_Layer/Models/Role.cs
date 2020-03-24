using System.Collections.Generic;

namespace Persistence_Layer.Models
{
    public class Role: Audit
    {
        public int RoleId { get; set; }
        public string Description { get; set; }
        public List<UserRole> UserRole { get; set; }
    }
}