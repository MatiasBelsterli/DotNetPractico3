using DataAccessLayer.IDALs;
using BusinessLayer.IBLs;
using BusinessLayer.BLs;
using PracticoClase1;
using DataAccessLayer;
using DataAccessLayer.DALs.Personas;

Console.WriteLine("Primera Aplicación con .NET");

using var dbContext = new DBContextCore();
IDAL_Personas _personas = new DAL_Personas_EF(dbContext);
IBL_Personas _personasBL = new BL_Personas(_personas);
Commands commands = new Commands(_personasBL);

Console.WriteLine("Comandos Posibles:");
Console.WriteLine("1 - Agregar Persona");
Console.WriteLine("2 - Listar Personas");
Console.WriteLine("3 - Eliminar Persona");
Console.WriteLine("4 - Salir");

Console.Write("Ingrese Comando> ");
string command = Console.ReadLine();

while(command != "4")
{
    try
    {
        switch (command)
        {
            case "1":
                commands.AddPersona();
                break;
            case "2":
                commands.ListPersonas();
                break;
            case "3":
                commands.RemovePersona();
                break;
            default:
                Console.WriteLine("Comando no reconocido");
                break;
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine("ERROR> " + ex.Message);
    }
    finally
    {
        Console.Write("Ingrese Comando> ");
        command = Console.ReadLine();
    }
}

Console.WriteLine("Gracias por usar la aplicación");
