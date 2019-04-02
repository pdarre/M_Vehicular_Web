namespace M_Vehicular_Web.Controllers
{
    using Data;
    using Helpers;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class VehiculosController : Controller
    {
        private readonly IVehiculoRepository vehiculoRepository;
        private readonly IUserHelper userHelper;

        public VehiculosController(IVehiculoRepository vehiculoRepository, IUserHelper userHelper)
        {
            this.vehiculoRepository = vehiculoRepository;
            this.userHelper = userHelper;
        }

        // GET: Vehiculos
        public ActionResult Index()
        {
            return View(this.vehiculoRepository.GetAll().OrderBy(v => v.Marca));
        }

        // GET: Vehiculos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await this.vehiculoRepository.GetByIdAsync(id.Value);
            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // GET: Vehiculos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehiculos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vehiculo vehiculo)
        {
            DateTime date = DateTime.Now.Date;
            vehiculo.FechaRegistro = date;
            
            if (ModelState.IsValid)
            {
                //TODO: Change for the logged user
                vehiculo.User = await this.userHelper.GetUserByEmailAsync("pablo@pablo.com");

                await this.vehiculoRepository.CreateAsync(vehiculo);
                return RedirectToAction(nameof(Index));

            }
            return View(vehiculo);
        }

        // GET: Vehiculos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await this.vehiculoRepository.GetByIdAsync(id.Value);
            if (vehiculo == null)
            {
                return NotFound();
            }
            return View(vehiculo);
        }

        // POST: Vehiculos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vehiculo vehiculo)
        {
            if (id != vehiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //TODO: Change for the logged user
                    vehiculo.User = await this.userHelper.GetUserByEmailAsync("pablo@pablo.com");
                    await this.vehiculoRepository.UpdateAsync(vehiculo);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await this.vehiculoRepository.ExistAsync(vehiculo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculo);
        }

        // GET: Vehiculos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = await this.vehiculoRepository.GetByIdAsync(id.Value);

            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // POST: Vehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehiculo = await this.vehiculoRepository.GetByIdAsync(id);
            await this.vehiculoRepository.DeleteAsync(vehiculo);
            return RedirectToAction(nameof(Index));
        }
    }
}
