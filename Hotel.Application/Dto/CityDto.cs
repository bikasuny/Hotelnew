using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Dto
{
    public class CityDto
    {
        public required string name {  get; set; }

        public required string latitude { get; set; }
        public required string longitude { get; set; }
    }
}
