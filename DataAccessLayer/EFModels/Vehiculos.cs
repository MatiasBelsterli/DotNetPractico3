using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.EFModels {
    public class Vehiculos {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Marcas { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Modelos { get; set; } = string.Empty;

        [Required]
        [StringLength(15)]
        public string Matriculas { get; set; } = string.Empty;

        [ForeignKey("Personas")]
        public int PersonasId { get; set; }
        public Personas Personas { get; set; }

        public Shared.Vehiculo ToVehiculo() {
            return new Shared.Vehiculo {
                Id = this.Id,
                Marca = this.Marcas,
                Modelo = this.Modelos,
                Matricula = this.Matriculas,
                PersonaId = this.PersonasId,
                Persona = this.Personas?.ToPersona()
            };
        }

        public static Vehiculos FromVehiculo(Shared.Vehiculo vehiculo) {
            return new Vehiculos {
                Id = vehiculo.Id,
                Marcas = vehiculo.Marca,
                Modelos = vehiculo.Modelo,
                Matriculas = vehiculo.Matricula,
                PersonasId = vehiculo.PersonaId,
                Personas = vehiculo.Persona != null ? Personas.FromPersona(vehiculo.Persona) : null
            };
        }
    }
}
