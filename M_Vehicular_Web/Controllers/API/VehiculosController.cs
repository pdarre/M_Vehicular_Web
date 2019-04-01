namespace M_Vehicular_Web.Controllers.API
{
    using M_Vehicular_Web.Data;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : Controller
    {
        private readonly IVehiculoRepository vehiculoRepository;

        public VehiculosController(IVehiculoRepository vehiculoRepository)
        {
            this.vehiculoRepository = vehiculoRepository;
        }

        [HttpGet]
        public ActionResult GetVehiculos()
        {
            return Ok(this.vehiculoRepository.GetAll());
        }
    }
}