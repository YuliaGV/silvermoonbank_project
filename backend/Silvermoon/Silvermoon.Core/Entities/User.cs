
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Silvermoon.Core.Entities
{


    public enum Role
    {
        Customer,
        Admin
    }


    [Table("users")]
    public class User
    {

        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters long.")]
        [Column("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lastname is required.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Lastname must be between 2 and 50 characters long.")]
        [Column("last_name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        [Column("password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [Column("role")]
        public Role Role { get; set; } = Role.Customer;

        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [JsonIgnore]
        public virtual Account? Account { get; set; }


    }


}
