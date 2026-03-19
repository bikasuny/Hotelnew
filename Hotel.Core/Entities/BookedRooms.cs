namespace Hotel.Core.Entities
{
    public class BookedRooms: BaseEntity
    {
        public DateTime  checkin {  get; set; }
        public DateTime checkout { get; set; }

        public int GuestAmount { get; set; }

        public int TotalPrice { get; set; }

        public int HotelId { get; set; }
    }
}
