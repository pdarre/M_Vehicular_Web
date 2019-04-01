namespace M_Vehicular_Web.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Vehiculo> Vehiculos { get; set; }

        public DbSet<Taller> Talleres { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}