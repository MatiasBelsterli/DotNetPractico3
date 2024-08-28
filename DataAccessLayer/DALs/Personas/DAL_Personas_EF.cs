using DataAccessLayer.IDALs;
using Shared;

namespace DataAccessLayer.DALs.Personas
{
    public class DAL_Personas_EF : IDAL_Personas
    {

        private DBContextCore _dbContext;

        public DAL_Personas_EF(DBContextCore dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(string documento)
        {
            var persona = _dbContext.Personas.FirstOrDefault(p => p.Documento == documento);
            if (persona != null)
            {
                _dbContext.Personas.Remove(persona);
                _dbContext.SaveChanges();
            }
        }

        public List<Persona> Get()
        {
            return _dbContext.Personas
                .Select(p => p.ToPersona())
                .ToList();
        }
        public Persona Get(string documento)
        {
            var persona = _dbContext.Personas
                .FirstOrDefault(p => p.Documento == documento);

            return persona?.ToPersona();
        }

        public void Insert(Persona persona)
        {
            var nuevaPersona = EFModels.Personas.FromPersona(persona);

            _dbContext.Personas.Add(nuevaPersona);
            _dbContext.SaveChanges();

            persona.Id = nuevaPersona.Id;
        }

        public void Update(Persona persona)
        {
            var personaExistente = _dbContext.Personas.FirstOrDefault(p => p.Id == persona.Id);
            if (personaExistente != null)
            {
                personaExistente.Documento = persona.Documento;
                personaExistente.Nombres = persona.Nombre;
                personaExistente.Apellidos = persona.Apellido;
                personaExistente.Telefono = persona.Telefono;
                personaExistente.Direccion = persona.Direccion;
                personaExistente.FechaNacimiento = persona.FechaNacimiento;

                _dbContext.SaveChanges();
            }
        }
    }
}
