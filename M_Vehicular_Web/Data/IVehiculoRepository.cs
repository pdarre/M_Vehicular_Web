namespace M_Vehicular_Web.Data
{
    using Models;
    using System.Linq;

    public interface IVehiculoRepository : IGenericRepository<Vehiculo>
    {
        IQueryable GetAllWithUsers();
    }
}
