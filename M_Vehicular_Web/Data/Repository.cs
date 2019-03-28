namespace M_Vehicular_Web.Data
{
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Repository : IRepository
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Vehiculo> GetVehiculos()
        {
            return this.context.Vehiculos.OrderBy(v => v.Marca);
        }

        public Vehiculo GetVehiculo(int id)
        {
            return this.context.Vehiculos.Find(id);
        }

        public void AddVehiculo(Vehiculo vehiculo)
        {
            this.context.Vehiculos.Add(vehiculo);
        }

        public void UpdateVehiculo(Vehiculo vehiculo)
        {
            this.context.Update(vehiculo);
        }

        public void RemoveVehiculo(Vehiculo vehiculo)
        {
            this.context.Vehiculos.Remove(vehiculo);
        }

        public bool VehiculoExists(int id)
        {
            return this.context.Vehiculos.Any(v => v.Id == id);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }
    }
}