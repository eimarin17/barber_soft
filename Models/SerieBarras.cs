using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberSoft.Models
{
    public class SerieBarras
    {
        public string name { get; set; }
        public int y { get; set; }


        public SerieBarras()
        {

        }

        public SerieBarras(string name, int y)
        {
            this.name = name;
            this.y = y;
        }

        public List<SeriePastel> GetDataDummy()
        {
            List<SeriePastel> lista = new List<SeriePastel>();

            lista.Add(new SeriePastel("Angular", 45));
            lista.Add(new SeriePastel("VueJS", 50));
            lista.Add(new SeriePastel("ReactJS", 60));
            lista.Add(new SeriePastel("CSS3", 34));
            lista.Add(new SeriePastel("HTML5", 20));

            return lista;
        }
    }
}
