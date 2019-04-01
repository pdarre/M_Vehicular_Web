namespace M_Vehicular_Web.Data
{
    using Models;

    public class VehiculoRepository : GenericRepository<Vehiculo>, IVehiculoRepository
    {
        public VehiculoRepository(DataContext context) : base(context)
        {
        }
    }
}