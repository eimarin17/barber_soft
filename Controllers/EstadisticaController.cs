using BarberSoft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberSoft.Controllers
{
    public class EstadisticaController : Controller
    {
        private readonly barber_softContext _context;

        public EstadisticaController(barber_softContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult DataPastel()
        {
            List<SeriePastel> dataSerie = _context.Empleados.Include(i => i.Ventas).Select(s => new
            SeriePastel
            {
                name = string.Concat(s.Nombres, " ", s.Apellidos),
                y = Convert.ToInt32(s.Ventas.Count()),
                sliced =false,
                selected = false
                //Nombre = string.Concat(s.Nombres," ",s.Apellidos),
                //TotalVentas = s.Ventas.Count()
            }).ToList();

            //SeriePastel serie = new SeriePastel();
            //return Json(serie.GetDataDummy());
            return Json(dataSerie);
        }
    }
}
