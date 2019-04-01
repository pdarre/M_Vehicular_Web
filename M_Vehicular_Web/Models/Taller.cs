namespace M_Vehicular_Web.Models
{
    using System;

    public class Taller : IModelo
    {
        public int Id { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string Descripcion { get; set; }

        public float Lat { get; set; }

        public float Long { get; set; }

        public byte[] Imagen { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
    }
}
