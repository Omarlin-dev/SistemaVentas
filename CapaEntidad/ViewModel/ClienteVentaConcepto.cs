using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.ViewModel
{
    public class ClienteVentaConcepto
    {
        public Cliente Cliente { get; set; }
        public IEnumerable<Concepto> Concepto { get; set; }
        public IEnumerable<Venta> Venta { get; set; }
        public Venta OneVenta { get; set; }
        public decimal total { get; set; }
    }
}
