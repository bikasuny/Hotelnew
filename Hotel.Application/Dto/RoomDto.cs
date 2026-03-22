using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Dto
{
    public class RoomDto
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

       
    }
}
