using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel
{
    public class ClienteVentaViewModel
    {
        public ClienteViewModel Cliente { get; set; }
        public IEnumerable<ConceptoViewModel> Concepto { get; set; }
        public IEnumerable<VentaViewModel> Venta { get; set; }
        public VentaViewModel OneVenta { get; set; }
        public decimal total { get; set; }
    }
}
