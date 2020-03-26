using System;
using Persistence_Layer.Models;

namespace Persistence_Layer.Interfaces
{
    public interface ITransaction
    {
        int AccountNo { get; set; }
        double Amount { get; set; }
        string Description2 { get; set; }
        DateTime TransactionDate { get; set; }
        TransactionType TransactionType { get; set; }
    }
}