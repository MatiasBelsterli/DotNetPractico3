using BusinessLayer.IBLs;
using DataAccessLayer.IDALs;
using Shared;

namespace BusinessLayer.BLs {
    public class BL_Vehiculos : IBL_Vehiculos {

        private readonly IDAL_Vehiculos _vehiculosDAL;
        public BL_Vehiculos(IDAL_Vehiculos vehiculosDAL) {
            _vehiculosDAL = vehiculosDAL;
        }

        public void Delete(string matricula) {
            _vehiculosDAL.Delete(matricula);
        }

        public List<Vehiculo> Get() {
            return _vehiculosDAL.Get();
        }

        public Vehiculo Get(string matricula) {
            return _vehiculosDAL.Get(matricula);
        }

        public void Insert(Vehiculo vehiculo) {
            _vehiculosDAL.Insert(vehiculo);
        }

        public void Update(Vehiculo vehiculo) {
            _vehiculosDAL.Update(vehiculo);
        }
    }
}
