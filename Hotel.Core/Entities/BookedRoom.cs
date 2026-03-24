using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Core.Entities
{
    [Table("bookedRooms")]
    public class BookedRoom: BaseEntity
    {
        public DateTime  checkin {  get; set; }
        public DateTime checkout { get; set; }

        public int GuestAmount { get; set; }

        public int TotalPrice { get; set; }

        public int HotelId { get; set; }

        public int UserId { get; set; }

        public int CityHotelId { get; set; }
    }
}
