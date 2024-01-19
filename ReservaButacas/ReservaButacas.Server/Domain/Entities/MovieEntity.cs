using System.ComponentModel.DataAnnotations;
using ReservaButacas.Server.Domain.Enums;

namespace ReservaButacas.Server.Domain.Entities
{
    public class MovieEntity : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public MovieGenreEnum Genre { get; set; }

        [Required]
        public short AllowedAge { get; set; }

        [Required]
        public short LengthMinutes { get; set; }


        public MovieEntity(string name, MovieGenreEnum genre, short allowedAge, short lengthMinutes)
        {
            Name = name;
            Genre = genre;
            AllowedAge = allowedAge;
            LengthMinutes = lengthMinutes;
        }
    }
}
