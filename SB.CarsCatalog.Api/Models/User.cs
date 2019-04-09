using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SB.CarsCatalog.Api.Models
{
    /// <summary>
    /// User
    /// </summary>
    [Table("User")]
    public class User
    {
        /// <summary>
        /// User id
        /// </summary>
        [Key]
        public int? Id { get; set; }
        /// <summary>
        /// User first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// User last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// User name
        /// </summary>
        [Required]
        public string UserName { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        [NotMapped]
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// Password hash
        /// </summary>
        public byte[] PasswordHash { get; set; }
        /// <summary>
        /// Password salt
        /// </summary>
        public byte[] PasswordSalt { get; set; }
        /// <summary>
        /// User's token
        /// </summary>
        [NotMapped]
        public string Token { get; set; }
    }
}
