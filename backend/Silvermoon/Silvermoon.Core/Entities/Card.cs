using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silvermoon.Core.Entities
{

    public enum CardType
    {
        Debit,
        Credit
    }

    public enum StatusCard
    {
        Active, 
        Inactive,
        Pending,
        Blocked
    }


    [Table("cards")]
    public class Card
    {

        [Key]
        [Column("card_id")]
        public int CardId { get; set; }

        [Required]
        [StringLength(16)]
        [Column("card_number")]
        public string CardNumber { get; set; }

        [Required]
        [StringLength(5)]
        [Column("expiration_date")]
        public string ExpirationDate { get; set; } // format MM/YY

        [Required]
        [StringLength(3)]
        [Column("security_code")]
        public string SecurityCode { get; set; } // CVV

        [Required]
        [Column("cardtype")]
        public CardType CardType{ get; set; }

        [Required]
        [Column("credit_limit")]
        public decimal CreditLimit { get; set; }

        [Required]
        [Column("available_balance")]
        public decimal AvailableBalance { get; set; }

        [Required]
        [Column("issue_date")]
        public DateTime IssueDate { get; set; }

        public StatusCard StatusCard { get; set; }

        [Required]
        [Column("account_id")]
        [ForeignKey("Account")]
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }

    }
}
