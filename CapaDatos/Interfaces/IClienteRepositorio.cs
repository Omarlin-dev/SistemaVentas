using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaEntidad.ViewModel;

namespace CapaDatos.Interfaces
{
    public interface IClienteRepositorio
    {
        Task<IEnumerable<Cliente>> GetClientes();
        Task<ClienteVentaConcepto> GetCliente(int Id);
        Task<List<Concepto>> GetClienteConceptos(int Id);
        Task<int> InsertarCliente(Cliente cliente);
        Task<bool> EditarCliente(Cliente cliente);
        Task<bool> EliminarCliente(int Id);
    }
}
