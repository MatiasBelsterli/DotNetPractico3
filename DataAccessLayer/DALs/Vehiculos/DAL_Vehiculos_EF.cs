using DataAccessLayer.IDALs;
using Shared;

namespace DataAccessLayer.DALs.Vehiculos {
    internal class DAL_Vehiculos_EF : IDAL_Vehiculos {
        private readonly DBContextCore _dbContext;

        public DAL_Vehiculos_EF(DBContextCore dbContext) {
            _dbContext = dbContext;
        }

        public void Delete(string matricula) {
            var vehiculo = _dbContext.Vehiculos.FirstOrDefault(v => v.Matriculas == matricula);
            if (vehiculo != null) {
                _dbContext.Vehiculos.Remove(vehiculo);
                _dbContext.SaveChanges();
            }
        }

        public List<Vehiculo> Get() {
            return _dbContext.Vehiculos
                .Select(v => v.ToVehiculo())
                .ToList();
        }

        public Vehiculo Get(string matricula) {
            var vehiculo = _dbContext.Vehiculos
                .FirstOrDefault(v => v.Matriculas == matricula);

            return vehiculo?.ToVehiculo();
        }

        public void Insert(Vehiculo vehiculo) {
            var nuevaVehiculo = EFModels.Vehiculos.FromVehiculo(vehiculo);
            _dbContext.Vehiculos.Add(nuevaVehiculo);
            _dbContext.SaveChanges();
        }

        public void Update(Vehiculo vehiculo) {
            var vehiculoExistente = _dbContext.Vehiculos
                .FirstOrDefault(v => v.Id == vehiculo.Id);

            if (vehiculoExistente != null) {
                vehiculoExistente.Marcas = vehiculo.Marca;
                vehiculoExistente.Modelos = vehiculo.Modelo;
                vehiculoExistente.Matriculas = vehiculo.Matricula;
                vehiculoExistente.PersonasId = vehiculo.PersonaId;

                _dbContext.SaveChanges();
            }
        }
    }
}
