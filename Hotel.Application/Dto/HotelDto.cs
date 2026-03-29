using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Dto
{
    public class HotelDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public string latitude { get; set; }
        public string longitude { get; set; }
    }
}
