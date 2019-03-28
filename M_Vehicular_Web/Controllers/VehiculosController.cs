namespace M_Vehicular_Web.Controllers
{
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;
    using System.Linq;

    public class VehiculosController : Controller
    {
        private readonly IRepository repository;

        public VehiculosController(IRepository repository)
        {
            this.repository = repository;
        }

        // GET: Vehiculos
        public ActionResult Index()
        {
            return View(this.repository.GetVehiculos());
        }

        // GET: Vehiculos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = this.repository.GetVehiculo(id.Value);
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
        public ActionResult Create(Vehiculo vehiculo)
        {
            DateTime date = DateTime.Now.Date;
            vehiculo.FechaRegistro = date;

            if (ModelState.IsValid)
            {
                this.repository.AddVehiculo(vehiculo);
                this.repository.SaveAllAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehiculo);
        }

        // GET: Vehiculos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = this.repository.GetVehiculo(id.Value);
            if (vehiculo == null)
            {
                return NotFound();
            }
            return View(vehiculo);
        }

        // POST: Vehiculos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Vehiculo vehiculo)
        {
            if (id != vehiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this.repository.UpdateVehiculo(vehiculo);
                    this.repository.SaveAllAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.repository.VehiculoExists(vehiculo.Id))
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
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehiculo = this.repository.GetVehiculo(id.Value);

            if (vehiculo == null)
            {
                return NotFound();
            }

            return View(vehiculo);
        }

        // POST: Vehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var vehiculo = this.repository.GetVehiculo(id);
            this.repository.RemoveVehiculo(vehiculo);
            this.repository.SaveAllAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
