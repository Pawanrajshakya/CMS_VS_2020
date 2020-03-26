using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Persistence_Layer.Interfaces;

namespace Persistence_Layer.Models
{
    public class Transaction : Audit, ITransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Date is required.")]
        public DateTime TransactionDate { get; set; }
        [Range(1, 100000000,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public double Amount { get; set; }
        [MaxLength(255)]
        public string Description1 { get; set; }
        [MaxLength(255)]
        public string Description2 { get; set; }

        [ForeignKey("TranType")]
        public TransactionType TransactionType { get; set; }
        public int TranType { get; set; }

        [ForeignKey("AccountNo")]
        public Account Account { get; set; }
        public int AccountNo { get; set; }

    }
}