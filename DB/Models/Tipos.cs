using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class Tipos
    {
        public int id { get; set; }
        public string? NameTipos { get; set; }

        //Navigation property
        public ICollection<Pokemones>? Pokemones { get; set; }
    }
}
