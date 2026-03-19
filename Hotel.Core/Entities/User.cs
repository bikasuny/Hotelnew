using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Core.Entities
{
    [Table("Users")]
    public class User: BaseEntity
    {
        [Required]
        public required string UserName { get; set; }

        [Required]

        public required string Password { get; set; }

        [Required]
        public required string PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public bool IsActive { get; set; }

    }
}
