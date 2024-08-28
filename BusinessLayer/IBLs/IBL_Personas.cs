using Shared;

namespace BusinessLayer.IBLs
{
    public interface IBL_Personas
    {
        List<Persona> Get();

        Persona Get(string documento);

        void Insert(Persona persona);

        void Update(Persona persona);

        void Delete(string documento);
    }
}
