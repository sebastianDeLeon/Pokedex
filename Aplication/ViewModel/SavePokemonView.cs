using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.ViewModel
{
    public class SavePokemonView
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Falto el nombre")]
        public string name { get; set; }

        [Required(ErrorMessage = "Falto la foto")]
        public string ImagenUrl { get; set; }

        [Required(ErrorMessage = "Falto el tipo")]
        public int Type1 { get; set; }
        public int? Type2 { get; set; }

        public string Type1N { get; set; }
        public string? Type2N { get; set; }

        [Required(ErrorMessage = "Falto la region")]
        public int RegionPokemon { get; set; }
        public string? NombreRegion { get; set; }
        //Navigation Property
        public List<SaveRegion>? regions { get; set; }
        public List<SaveTipo>? tipos { get; set; }
    }
}
