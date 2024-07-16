using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Silvermoon.Core.Entities
{


    public enum TransactionType
    {
        Transfer,
        Withdrawal,
        Deposit
    }


    [Table("financial_transactions")]
    public class FinancialTransaction
    {

        [Key]
        [Column("transaction_id")]
        public int TransactionId { get; set; }

        [Required]
        [Column("type")]
        public TransactionType Type { get; set; }

        [Required]
        [Column("amount")]
        public decimal Amount { get; set; }

        [Required]
        [Column("date")]
        public DateTime TransactionDate { get; set; }

   

    }
}
