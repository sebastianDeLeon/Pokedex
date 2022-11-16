using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class Pokemones
    {
        public int id { get; set; }
        public string name { get; set; }
        public string ImagenUrl { get; set; }
        public int Type1 { get; set; }
        public int? Type2 { get; set; }
        public int RegionPokemon { get; set; }

        //Navigation Property

        public Regiones? Regiones { get; set; }
        public Tipos? Tipos { get; set; }
        public Tipo2? Tipos2 { get; set; }
    }
}
