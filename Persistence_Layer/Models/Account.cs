using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Persistence_Layer.Interfaces;

namespace Persistence_Layer.Models
{
    public class Account : Audit
    {
        public Account()
        {
            IsVisible = true;
            IsActive = true;
        }

        [Key]
        public int AccountNo { get; set; }

        public int ClientId { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public double Balance { get; private set; }
        [ForeignKey("AccountTypeId")]
        public AccountType AccountType { get; set; }
        [Required(ErrorMessage = "Account Type is required")]
        public int AccountTypeId { get; set; }
        public bool IsMain { get; set; } //One client can have multiple account

        #region Detail
        [Required(ErrorMessage = "FirstName is required")]
        [MaxLength(255)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        [MaxLength(255)]
        public string LastName { get; set; }
        [MaxLength(12)]
        public string Phone { get; set; }
        [MaxLength(55)]
        public string Email { get; set; }
        [MaxLength(255)]
        public string Address1 { get; set; }
        [MaxLength(255)]
        public string Address2 { get; set; }
        [MaxLength(2)]
        public string State { get; set; }
        [MaxLength(20)]
        public string ZipCode { get; set; }
        public Relationship Relationship { get; set; }
        public int RelationshipId { get; set; } //Relationship with main account
        #endregion
        public List<Transaction> Transactions { get; set; }
        public int Order { get; set; }
    }
}