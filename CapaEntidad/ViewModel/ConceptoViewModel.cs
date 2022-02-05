using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel
{
    public class ConceptoViewModel
    {
        public int idConcepto { get; set; }
        public int idVenta { get; set; }
        public int idCliente { get; set; } 
        public string nombre { get; set; }
        public int cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal total { get; set; }

    }
}
