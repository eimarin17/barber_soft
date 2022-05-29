using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarberSoft.Models;

namespace BarberSoft.Controllers
{
    public class VentasController : Controller
    {
        private readonly barber_softContext _context;

        public VentasController(barber_softContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var barber_softContext = _context.Ventas.Include(v => v.Empleado).Include(v => v.Servicio);
            return View(await barber_softContext.ToListAsync());
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventas = await _context.Ventas
                .Include(v => v.Empleado)
                .Include(v => v.Servicio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ventas == null)
            {
                return NotFound();
            }

            return View(ventas);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            //ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Nombres");
            ViewData["EmpleadoId"] = new SelectList((from e in _context.Empleados.ToList() select new { 
            Id = e.Id,
            FullName = e.Nombres + " " + e.Apellidos
            }),
            "Id",
            "FullName"
            );

            ViewData["ServicioId"] = new SelectList(_context.Servicios, "Id", "Nombre");
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ServicioId,EmpleadoId")] Ventas ventas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellidos", ventas.EmpleadoId);
            ViewData["ServicioId"] = new SelectList(_context.Servicios, "Id", "Nombre", ventas.ServicioId);
            return View(ventas);
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventas = await _context.Ventas.FindAsync(id);
            if (ventas == null)
            {
                return NotFound();
            }

            ViewData["EmpleadoId"] = new SelectList((from e in _context.Empleados.ToList()
                                                     select new
                                                     {
                                                         Id = e.Id,
                                                         FullName = e.Nombres + " " + e.Apellidos
                                                     }),
                                                   "Id",
                                                   "FullName"
           );

            //ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellidos", ventas.EmpleadoId);
            ViewData["ServicioId"] = new SelectList(_context.Servicios, "Id", "Nombre", ventas.ServicioId);
            return View(ventas);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ServicioId,EmpleadoId")] Ventas ventas)
        {
            if (id != ventas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentasExists(ventas.Id))
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
            ViewData["EmpleadoId"] = new SelectList(_context.Empleados, "Id", "Apellidos", ventas.EmpleadoId);
            ViewData["ServicioId"] = new SelectList(_context.Servicios, "Id", "Nombre", ventas.ServicioId);
            return View(ventas);
        }

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventas = await _context.Ventas
                .Include(v => v.Empleado)
                .Include(v => v.Servicio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ventas == null)
            {
                return NotFound();
            }

            return View(ventas);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var ventas = await _context.Ventas.FindAsync(id);
            _context.Ventas.Remove(ventas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentasExists(long id)
        {
            return _context.Ventas.Any(e => e.Id == id);
        }
    }
}
