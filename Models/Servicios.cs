using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BarberSoft.Models
{
    public partial class Servicios
    {
        public Servicios()
        {
            Ventas = new HashSet<Ventas>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Precio { get; set; }

        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}
