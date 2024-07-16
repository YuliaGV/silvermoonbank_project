
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace Silvermoon.Core.Entities
{
    [Table("transfer_details")]
    public class TransferDetail
    {
        [Key]
        [Column("tranfer_details_id")]
        public int TransferDetailsId { get; set; }

        [Required]
        [Column("from_account")]
        public string FromAccount { get; set; }

        [Required]
        [Column("to_account")]
        public string ToAccount { get; set; }

        [Required]
        [ForeignKey("FinancialTransaction")]
        [Column("transaction_id")]
        public int TransactionId { get; set; }

        public virtual FinancialTransaction FinancialTransaction { get; set; }


    }
}
