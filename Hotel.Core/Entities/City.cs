using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Core.Entities
{
    [Table("Cities")]
    public class City: BaseEntity
    {
        [Required]
        public required string name { get; set; }

        public required string latitude { get; set; }
        public required string longitude { get; set; }

        public List<Hotel>? hotels { get; set; }
    }
}
