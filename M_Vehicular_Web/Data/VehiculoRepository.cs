namespace M_Vehicular_Web.Data
{
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class VehiculoRepository : GenericRepository<Vehiculo>, IVehiculoRepository
    {
        private readonly DataContext context;

        public VehiculoRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return this.context.Vehiculos.Include(v => v.User);
        }
    }
}