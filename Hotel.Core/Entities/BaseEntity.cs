using System.ComponentModel.DataAnnotations;

namespace Hotel.Core.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
