using BusinessLayer.IBLs;
using Shared;

namespace PracticoClase1
{
    public class Commands
    {
        IBL_Personas _personasBL;

        public Commands(IBL_Personas personasBL)
        {
            _personasBL = personasBL;
        }

        public void AddPersona() {
            Console.Write("Ingrese Documento: ");
            string documento = Console.ReadLine();

            Console.Write("Ingrese Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese Apellido: ");
            string apellido = Console.ReadLine();

            Console.Write("Ingrese Teléfono: ");
            string telefono = Console.ReadLine();

            Console.Write("Ingrese Dirección: ");
            string direccion = Console.ReadLine();

            Console.Write("Ingrese Fecha de Nacimiento (yyyy-MM-dd): ");
            DateTime fechaNacimiento;
            while (!DateTime.TryParse(Console.ReadLine(), out fechaNacimiento)) {
                Console.Write("Fecha no válida. Ingrese Fecha de Nacimiento (yyyy-MM-dd): ");
            }

            Persona nuevaPersona = new Persona {
                Documento = documento,
                Nombre = nombre,
                Apellido = apellido,
                Telefono = telefono,
                Direccion = direccion,
                FechaNacimiento = fechaNacimiento
            };

            _personasBL.Insert(nuevaPersona);

            Console.WriteLine("Persona agregada exitosamente.");
        }

        public void ListPersonas() {
            var personas = _personasBL.Get();
            foreach (var persona in personas) {
                persona.PrintTable();
            }
        }

        public void RemovePersona()
        {
            Console.WriteLine("Ingrese el documento de la persona a eliminar: ");
            string documento = Console.ReadLine();

            _personasBL.Delete(documento);
        }
    }
}
