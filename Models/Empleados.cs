using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BarberSoft.Models
{
    public partial class Empleados
    {
        public Empleados()
        {
            Ventas = new HashSet<Ventas>();
        }

        public long Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Documento { get; set; }

        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
