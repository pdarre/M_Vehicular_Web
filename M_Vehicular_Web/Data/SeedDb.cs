namespace M_Vehicular_Web.Data
{
    using Microsoft.AspNetCore.Identity;
    using Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly UserManager<User> userManager;

        public SeedDb(DataContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task SeedAsync()
        {
            DateTime date = DateTime.Now.Date;
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userManager.FindByEmailAsync("pablo@pablo.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Pablo",
                    LastName = "Darre",
                    Email = "pablo@pablo.com",
                    UserName = "pablo@pablo.com"
                };

                var result = await this.userManager.CreateAsync(user, "pablo1");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }

            if (!this.context.Vehiculos.Any())
            {
                this.AddVehiculo("AAA1234", "Nissan", "Sentra", 2010, date, user);
                this.AddVehiculo("BBB1234", "Ford", "Fiesta", 2000, date, user);
                this.AddVehiculo("CCC1234", "Toyota", "Hilux", 2005, date, user);
                await this.context.SaveChangesAsync();
            }
        }   

        private void AddVehiculo(string matricula, string marca, string modelo, int anio, DateTime date, User user)
        {
            this.context.Vehiculos.Add(new Vehiculo
            {
                Matricula = matricula,
                Marca = marca,
                Modelo = modelo,
                Anio = anio,
                FechaRegistro = date, 
                User = user
            });
        }
    }

}
