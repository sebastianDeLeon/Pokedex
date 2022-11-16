using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class Regiones
    {
        public int id { get; set; }
        public string NameRegion { get; set; }

        //Navigation property
        public ICollection<Pokemones>? Pokemones { get; set;}
    }
}
