using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Core.Entities
{
    [Table("rooms")]
    public class Rooms: BaseEntity
    {
        public int MaxGuestAmount { get; set; }

        

        public RoomType roomType { get; set; }

        public double PricePerNight { get; set; }

        public enum RoomType
        {
            Single,
            Double,
            Deluxe
        }

        public int HotelId { get; set; }
        public Hotel hotel { get; set; }
    }
}
