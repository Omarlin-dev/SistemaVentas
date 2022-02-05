using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaEntidad.ViewModel;
namespace CapaDatos.Interfaces
{
    public interface IVentaRepositorio
    {
        Task<IEnumerable<Venta>> GetVentas();
        Task<Venta> GetVenta(int Id);
        Task<List<Concepto>> GetVentaConceptos(int Id);
        Task<bool> InsertarVentaConcepto(ClienteVentaConcepto ventaConcepto);
        Task<bool> EliminarVenta(int Id);
    }
}
