namespace Shared {
    public class Persona {
        public int Id { get; set; }
        public string Documento { get; set; } = "";
        public string Nombre { get; set; } = "-- Sin Nombre --";
        public string Apellido { get; set; } = "-- Sin Apellido --";
        public string Telefono { get; set; } = "-- Sin Telefono --";
        public string Direccion { get; set; } = "-- Sin Direccion --";
        public DateTime FechaNacimiento { get; set; } = DateTime.MinValue;

        public Persona() { }

        public Persona(int id, string documento, string nombre, string apellido, string telefono, string direccion, DateTime fechaNacimiento) {
            Id = id;
            Documento = documento;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Direccion = direccion;
            FechaNacimiento = fechaNacimiento;
        }

        public void Print() {
            Console.WriteLine("-- Persona --");
            Console.WriteLine("ID: " + Id);
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Apellido: " + Apellido);
            Console.WriteLine("Documento: " + Documento);
            Console.WriteLine("Telefono: " + Telefono);
            Console.WriteLine("Direccion: " + Direccion);
            Console.WriteLine("Fecha de Nacimiento: " + FechaNacimiento.ToShortDateString());
        }

        public void PrintTable() {
            Console.WriteLine("| " + Id + " | " + Documento + " | " + Nombre + " | " + Apellido + " | " + Telefono + " | " + Direccion + " | " + FechaNacimiento.ToShortDateString() + " |");
        }
    }
}
