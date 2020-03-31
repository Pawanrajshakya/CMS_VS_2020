namespace Persistence_Layer.Models
{
    public class AccountType: Audit
    {
        public string Description { get; set; }
        public int Order { get; set; }
    }
}