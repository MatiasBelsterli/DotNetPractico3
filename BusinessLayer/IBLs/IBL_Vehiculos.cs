using Shared;

namespace BusinessLayer.IBLs {
    public interface IBL_Vehiculos {
        List<Vehiculo> Get();

        Vehiculo Get(string matricula);

        void Insert(Vehiculo vehiculo);

        void Update(Vehiculo vehiculo);

        void Delete(string matricula);
    }
}
