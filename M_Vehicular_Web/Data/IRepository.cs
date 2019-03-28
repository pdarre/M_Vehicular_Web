namespace M_Vehicular_Web.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IRepository
    {
        void AddVehiculo(Vehiculo vehiculo);

        Vehiculo GetVehiculo(int id);

        IEnumerable<Vehiculo> GetVehiculos();

        void RemoveVehiculo(Vehiculo vehiculo);

        Task<bool> SaveAllAsync();

        void UpdateVehiculo(Vehiculo vehiculo);

        bool VehiculoExists(int id);
    }
}