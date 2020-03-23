using System.ComponentModel.DataAnnotations;

namespace Persistence_Layer.Models
{
    public class Client : Audit
    {
        [Key]
        public int ClientId { get; set; }
        public string Name { get; set; }
    }
}