using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BarberSoft.Models
{
    public partial class Ventas
    {
        public long Id { get; set; }
        public long ServicioId { get; set; }
        public long EmpleadoId { get; set; }

        public virtual Empleados Empleado { get; set; }
        public virtual Servicios Servicio { get; set; }
    }
}
