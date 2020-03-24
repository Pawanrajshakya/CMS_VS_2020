using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Persistence_Layer.Models
{
    public class Client : Audit
    {
        [Key]
        public int ClientId { get; set; }
        public string Name { get; set; }

        public Business Business { get; set; }
        public int BusinessId { get; set; }

        public List<Account> Accounts { get; set; }
    }
}