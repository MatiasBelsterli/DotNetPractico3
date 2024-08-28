using Shared;

namespace DataAccessLayer.IDALs {
    public interface IDAL_Vehiculos {
        List<Vehiculo> Get();

        Vehiculo Get(string matricula);

        void Insert(Vehiculo vehiculo);

        void Update(Vehiculo vehiculo);

        void Delete(string matricula);
    }
}
