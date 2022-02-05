using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Interfaces;
using CapaEntidad;
using CapaEntidad.ViewModel; 

namespace CapaDatos.Repositorios
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        protected readonly SistemaVentaEntities context;

        public ClienteRepositorio(SistemaVentaEntities context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await context.Cliente.ToListAsync();
        }

        public async Task<ClienteVentaConcepto> GetCliente(int Id)
        {
            var modelEnviar = new ClienteVentaConcepto();

            modelEnviar.Cliente = await context.Cliente.FirstOrDefaultAsync(x => x.idCliente == Id);

            var Concepto = await (from v in context.Venta.Where(x => x.idCliente == Id)
                                  join c in context.Concepto
                                  on v.idVenta equals c.idVenta
                                  select c).ToListAsync();

            modelEnviar.total = Concepto.Sum(x => x.total);

            return modelEnviar;
        }

        public async Task<List<Concepto>> GetClienteConceptos(int Id)
        {
            var modelEnviar = new List<Concepto>();

            modelEnviar = await (from v in context.Venta.Where(x => x.idCliente == Id)
                                  join c in context.Concepto
                                  on v.idVenta equals c.idVenta
                                  select c).ToListAsync();                      

            return modelEnviar;
        }

        public async Task<int> InsertarCliente(Cliente cliente)
        {
            int IdAutoGenerado = 0;
            try
            {
                context.Cliente.Add(cliente);
                await context.SaveChangesAsync();

                IdAutoGenerado = cliente.idCliente;
            }
            catch 
            {

                IdAutoGenerado = 0;
            }
              

            return IdAutoGenerado;
        }

        public async Task<bool> EditarCliente(Cliente cliente)
        {
            bool resultado = false;

            try
            {
                context.Entry(cliente).State = EntityState.Modified;
                await context.SaveChangesAsync();

                resultado = true;
            }
            catch 
            {

                resultado = false;
            }

            return resultado;
        }

        public async Task<bool> EliminarCliente(int Id)
        {
            bool resultado= false;

            try
            {
                var clienteEliminar = await GetCliente(Id);
                if(clienteEliminar != null)
                {
                    context.Cliente.Remove(clienteEliminar.Cliente);
                    await context.SaveChangesAsync();

                    resultado = true;
                }
               
            }
            catch
            {

                resultado = false;
            }

            return resultado;
        }               
    }
}
