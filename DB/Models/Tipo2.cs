using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class Tipo2
    {
        public int id { get; set; }
        public string? NameTipos { get; set; }
        public ICollection<Pokemones>? Pokemones2 { get; set; }
    }
}
