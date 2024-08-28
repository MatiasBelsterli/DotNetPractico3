using Shared;

namespace DataAccessLayer.IDALs
{
    public interface IDAL_Personas
    {
        List<Persona> Get();

        Persona Get(string documento);

        void Insert(Persona persona);

        void Update(Persona persona);

        void Delete(string documento);
    }
}
