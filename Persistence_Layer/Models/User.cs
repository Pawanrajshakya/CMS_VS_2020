using System.Collections.Generic;

namespace Persistence_Layer.Models
{
    public class User: Audit
    {
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public List<UserRole> UserRole { get; set; }
    }
}