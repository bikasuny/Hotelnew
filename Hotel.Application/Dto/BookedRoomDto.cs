using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Dto
{
    public class BookedRoomDto
    {
        public string Name { get; set; }
        public DateTime checkin { get; set; }
        public DateTime checkout { get; set; }

        public int GuestAmount { get; set; }

        public int TotalPrice { get; set; }

        public int HotelId { get; set; }
    }
}
