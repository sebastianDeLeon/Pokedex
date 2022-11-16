using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.ViewModel
{
    public class SaveRegion
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Debe ingresar la region")]
        public string? NameRegion { get; set; }
    }
}
