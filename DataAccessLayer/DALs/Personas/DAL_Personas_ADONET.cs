using DataAccessLayer.IDALs;
using Shared;
using Microsoft.Data.SqlClient;

namespace DataAccessLayer.DALs.Personas
{
    public class DAL_Personas_ADONET : IDAL_Personas
    {

        // TODO Mover a archivo de config
        private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=practico1;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public void Delete(string documento)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Personas WHERE Documento = @Documento";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Documento", documento);

                command.ExecuteNonQuery();
            }
        }

        public List<Persona> Get()
        {
            List<Persona> personas = new List<Persona>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Id, Nombre, Documento FROM Personas";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Persona persona = new Persona
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Documento = reader.GetString(2),
                        };

                        personas.Add(persona);
                    }
                }
            }

            return personas;
        }

        public Persona Get(string documento)
        {
            Persona persona = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Id, Nombre, Documento FROM Personas WHERE Documento = @Documento";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Documento", documento);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        persona = new Persona
                        {
                            Id = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Documento = reader.GetString(3),
                            Telefono = reader.IsDBNull(4) ? null : reader.GetString(4),
                            Direccion = reader.IsDBNull(5) ? null : reader.GetString(5),
                            FechaNacimiento = reader.IsDBNull(6) ? DateTime.MinValue : reader.GetDateTime(6)
                        };
                    }
                }
            }

            return persona;
        }

        public void Insert(Persona persona)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Personas (Nombre, Documento) VALUES (@Nombre, @Documento)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                command.Parameters.AddWithValue("@Documento", persona.Documento);

                var newId = Convert.ToInt32(command.ExecuteScalar());
                persona.Id = newId;
            }
        }

        public void Update(Persona persona)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Personas SET Nombre = @Nombre, Documento = @Documento WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@Nombre", persona.Nombre);
                command.Parameters.AddWithValue("@Documento", persona.Documento);
                command.Parameters.AddWithValue("@Id", persona.Id);

                command.ExecuteNonQuery();
            }
        }
    }
}
