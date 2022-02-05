using CapaDatos.Interfaces;
using CapaEntidad;
using CapaEntidad.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repositorios
{
    public class VentaConceptoRepositorio : IVentaRepositorio
    {
        private readonly SistemaVentaEntities contex;

        public VentaConceptoRepositorio(SistemaVentaEntities contex)
        {
            this.contex = contex;
        }

        public async Task<IEnumerable<Venta>> GetVentas()
        {
            return await contex.Venta.Include("Cliente").ToListAsync();
        }

        public async Task<Venta> GetVenta(int Id)
        {
            return await contex.Venta.Include("Cliente").FirstOrDefaultAsync(x =>x.idVenta ==Id);
        }

        public async Task<List<Concepto>> GetVentaConceptos(int Id)
        {
            var modelEnviar = new List<Concepto>();

            modelEnviar = await (from v in contex.Venta.Where(x => x.idVenta == Id)
                                 join c in contex.Concepto
                                 on v.idVenta equals c.idVenta
                                 select c).ToListAsync();

            return modelEnviar;
        }

        public async Task<bool> InsertarVentaConcepto(ClienteVentaConcepto ventaConcepto)
        {
            bool resultado = false;

            try
            {
                Venta venta = new Venta();

                venta.fecha = DateTime.Now.Date;
                venta.idCliente = ventaConcepto.OneVenta.idCliente;

                contex.Venta.Add(venta);
                await contex.SaveChangesAsync();

                foreach (var conceptoItem in ventaConcepto.Concepto)
                {
                    Concepto concepto = new Concepto();
                    concepto.nombre = conceptoItem.nombre;
                    concepto.idVenta = venta.idVenta;
                    concepto.cantidad = conceptoItem.cantidad;
                    concepto.precioUnitario = conceptoItem.precioUnitario;
                    concepto.total = conceptoItem.cantidad * conceptoItem.precioUnitario;
                    contex.Concepto.Add(concepto);
                }

                await contex.SaveChangesAsync();

                resultado = true;
            }
            catch 
            {
                resultado = false;
            }

            return resultado;
        }

        public async Task<bool> EliminarVenta(int Id)
        {
            bool resultado = false;
            
            try
            {
                bool comprobarConcepto = await contex.Concepto.AnyAsync(d => d.idVenta == Id);
                var ventaEliminar = await GetVenta(Id);

                if (!comprobarConcepto)
                {
                    contex.Venta.Remove(ventaEliminar);
                    await contex.SaveChangesAsync();
                    resultado = true;
                }
                else
                {
                    resultado = false;
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
