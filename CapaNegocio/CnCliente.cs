using CapaDatos.Repositorios;
using CapaEntidad;
using CapaEntidad.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CnCliente
    {
        private readonly repoUnitOfWork repositorios;

        public CnCliente(SistemaVentaEntities context)
        {
            repositorios = new repoUnitOfWork(context);
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await repositorios.repoCliente().GetClientes();
        }

        public async Task<ClienteVentaConcepto> GetCliente(int Id)
        {
            return await repositorios.repoCliente().GetCliente(Id);
        }

        public async Task<List<Concepto>> GetClienteConceptos(int Id)
        {
            return await repositorios.repoCliente().GetClienteConceptos(Id);
        }

        public async Task<int> InsertarCliente(Cliente cliente)
        {
            return await repositorios.repoCliente().InsertarCliente(cliente);
        }

        public async Task<bool> EditarCliente(Cliente cliente)
        {
            if(cliente.idCliente > 0)
            {
                return await repositorios.repoCliente().EditarCliente(cliente);
            }

            return false;
        }

        public async Task<bool> EliminarCliente(int Id)
        {
            bool resultado = false;

            if(Id != 0)
            {
                resultado = await repositorios.repoCliente().EliminarCliente(Id);
            }

            return resultado;
        }
    }
}
