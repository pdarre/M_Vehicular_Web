namespace M_Vehicular_Web.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;

    public class DataContext : DbContext
    {
        public DbSet<Vehiculo> Vehiculos { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }

}
