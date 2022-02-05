using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaEntidad.ViewModel;
using CapaDatos.Repositorios;

namespace CapaNegocio
{
    public class CnVenta
    {
        private readonly repoUnitOfWork repositorios;

        public CnVenta(SistemaVentaEntities context)
        {
            repositorios = new repoUnitOfWork(context);
        }
        public async Task<IEnumerable<Venta>> GetVentas()
        {
            return await repositorios.repoCoceptoVenta().GetVentas();
        }

        public async Task<bool> InsertarVentaConcepto(ClienteVentaConcepto ventaConcepto)
        {
            return await repositorios.repoCoceptoVenta().InsertarVentaConcepto(ventaConcepto);
        }

        public async Task<Venta> GetVenta(int Id)
        {
            if(Id != 0)
            {
                return await repositorios.repoCoceptoVenta().GetVenta(Id);
            }

            return new Venta();
        }

        public async Task<List<Concepto>> GetVentaConceptos(int Id)
        {
            if (Id != 0)
            {
                return await repositorios.repoCoceptoVenta().GetVentaConceptos(Id);
            }

            return new List<Concepto>();
        }

        public async Task<bool> EliminarVenta(int Id)
        {
            var ventaComprobar = await repositorios.repoCoceptoVenta().GetVenta(Id);

            if(Id != 0)
            {
                if(ventaComprobar != null)
                {
                    return await repositorios.repoCoceptoVenta().EliminarVenta(Id);
                }
            }

            return false;

        }
    }
}
