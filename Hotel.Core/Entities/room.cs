using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Core.Entities
{
    [Table("rooms")]
    public class room: BaseEntity
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
        public CityHotel hotel { get; set; }
    }
}
