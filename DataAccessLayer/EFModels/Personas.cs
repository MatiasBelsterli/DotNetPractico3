using Shared;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.EFModels {
    public class Personas {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Documento { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Nombres { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Apellidos { get; set; } = string.Empty;

        [StringLength(15)]
        public string Telefono { get; set; } = string.Empty;

        [StringLength(200)]
        public string Direccion { get; set; } = string.Empty;

        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }

        public Persona ToPersona() {
            return new Persona(Id, Documento, Nombres, Apellidos, Telefono, Direccion, FechaNacimiento);
        }

        public static Personas FromPersona(Persona persona) {
            return new Personas {
                Id = persona.Id,
                Documento = persona.Documento,
                Nombres = persona.Nombre,
                Apellidos = persona.Apellido,
                Telefono = persona.Telefono,
                Direccion = persona.Direccion,
                FechaNacimiento = persona.FechaNacimiento
            };
        }
    }
}
