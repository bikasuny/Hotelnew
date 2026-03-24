using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Dto
{
    public class UserDto
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Surname { get; set; }

        public required string PersonalNumber { get; set; }

        public bool IsResident => PersonalNumber?.Length == 11;

        public string? Email { get; set; }

        public required string PhoneNumber { get; set; }

        public string? Address { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
