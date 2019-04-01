namespace M_Vehicular_Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Vehiculo : IModelo
    {
        public int Id { get; set; }

        [Required]
        public string Matricula { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        [Display(Name = "Año")]
        public int Anio { get; set; }

        [Required]
        [Display(Name = "Registrado")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaRegistro { get; set; }

        public string Notas { get; set; }
        
        public User User { get; set; }

    }
}
