using System.Collections.Generic;

namespace Persistence_Layer.Models
{
    public class Client : Audit
    {
        public string Name { get; set; }

        public Business Business { get; set; }
        
        public int BusinessId { get; set; }

        public List<Account> Accounts { get; set; }
    }
}