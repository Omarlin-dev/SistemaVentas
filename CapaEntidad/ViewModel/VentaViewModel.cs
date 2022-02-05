using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel
{
    public class VentaViewModel
    {
        public int idVenta { get; set; }
        public int idCliente { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime fecha { get; set; }
        public ClienteViewModel Cliente { get; set; }
    }
}
