using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace Silvermoon.Core.Entities
{

    public enum Status
    {
        Active,
        Inactive,
        Pending,
        Suspended
    }

    [Table("accounts")]
    public class Account
    {

        [Key]
        [Column("account_id")]
        public int AccountId { get; set; }

        [Required]
        [Column("account_number")]
        public string AccountNumber { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column("balance")]
        public decimal Balance { get; set; }

        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        [Column("status")]
        public Status Status { get; set; } = Status.Active;


        [Required]
        [Column("user_id")]
        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set;  }

        [JsonIgnore]
        public ICollection<Card> Cards { get; } = new List<Card>();

    }
}
