using System.ComponentModel.DataAnnotations;

namespace ReservaButacas.Server.Domain.Entities
{
    public class RoomEntity : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public short Number { get; set; } 

    }
}
