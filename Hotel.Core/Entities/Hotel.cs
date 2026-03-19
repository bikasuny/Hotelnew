using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Core.Entities
{
    [Table("hotels")]
    public class Hotel: BaseEntity
    {
        [Required]
        public required string Name { get; set; }

        public string Description { get; set; }

        public string latitude { get; set; }
        public string longitude { get; set; }

        
        public string Stars {  get; set; }


        public List<Rooms> rooms { get; set; }

        public List<BookedRooms>  BookedRooms { get; set; }
    }
}
