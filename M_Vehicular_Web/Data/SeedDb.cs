namespace M_Vehicular_Web.Data
{
    using Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext context;

        public SeedDb(DataContext context)
        {
            this.context = context;
        }

        public async Task SeedAsync()
        {
            DateTime date = DateTime.Now.Date;
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Vehiculos.Any())
            {
                this.AddProduct("AAA1234", "Nissan", "Sentra", 2010, date);
                this.AddProduct("BBB1234", "Ford", "Fiesta", 2000, date);
                this.AddProduct("CCC1234", "Toyota", "Hilux", 2005, date);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string matricula, string marca, string modelo, int anio, DateTime date)
        {
            this.context.Vehiculos.Add(new Vehiculo
            {
                Matricula = matricula,
                Marca = marca,
                Modelo = modelo,
                Anio = anio,
                FechaRegistro = date
            });
        }
    }

}
