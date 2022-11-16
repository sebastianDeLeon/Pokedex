using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.ViewModel
{
    public class SaveTipo
    {
        public int id { get; set; }
        //[Required(ErrorMessage = "Debe ingresar el tipo")]
        public string NameTipos { get; set; }
    }
}
