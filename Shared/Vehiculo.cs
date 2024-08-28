namespace Shared {
    public class Vehiculo {
        public int Id { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Matricula { get; set; } = string.Empty;

        public int PersonaId { get; set; }
        public Persona Persona { get; set; }

        public Vehiculo() { }

        public Vehiculo(int id, string marca, string modelo, string matricula, int personaId) {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Matricula = matricula;
            PersonaId = personaId;
        }

        public void Print() {
            Console.WriteLine("-- Vehiculo --");
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Marca: " + Marca);
            Console.WriteLine("Modelo: " + Modelo);
            Console.WriteLine("Matricula: " + Matricula);
            Console.WriteLine("Persona ID: " + PersonaId);
            if (Persona != null) {
                Console.WriteLine("Propietario: " + Persona.Nombre + " " + Persona.Apellido);
            }
        }

        public void PrintTable() {
            Console.WriteLine("| " + Id + " | " + Marca + " | " + Modelo + " | " + Matricula + " | " + PersonaId + " |");
        }
    }
}
