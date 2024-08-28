using DataAccessLayer.IDALs;
using Shared;

namespace DataAccessLayer.DALs.Personas
{
    public class DAL_Personas : IDAL_Personas
    {
        private Dictionary<string, Persona> personas = new Dictionary<string, Persona>();

        public List<Persona> Get()
        {
            return personas.Values.ToList();
        }

        public Persona Get(string documento)
        {
            return personas[documento];
        }

        public void Insert(Persona persona)
        {
            personas.Add(persona.Documento, persona);
        }

        public void Update(Persona persona)
        {
            personas[persona.Documento] = persona;
        }

        public void Delete(string documento)
        {
            personas.Remove(documento);
        }
    }
}
