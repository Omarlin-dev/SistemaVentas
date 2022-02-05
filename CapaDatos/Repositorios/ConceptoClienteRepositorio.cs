using CapaDatos.Interfaces;
using CapaEntidad;
using System.Data.Entity;
using System.Threading.Tasks;
using System;
using System.Data.Entity.Migrations;

namespace CapaDatos.Repositorios
{
    public class ConceptoClienteRepositorio : IConceptoClienteRepositorio
    {
        private readonly SistemaVentaEntities context;

        public ConceptoClienteRepositorio(SistemaVentaEntities context)
        {
            this.context = context;
        }

        public async Task<Concepto> GetConcepto(int Id)
        {
            return await context.Concepto.FirstOrDefaultAsync(d => d.idConcepto == Id);
        }

        public async Task<int> InsertarConcepto(Concepto concepto)
        {
            int IdAutoGenerado = 0;

            try
            {
                concepto.total = concepto.cantidad * concepto.precioUnitario;

                context.Concepto.Add(concepto);
                await context.SaveChangesAsync();

                IdAutoGenerado = concepto.idConcepto;
            }
            catch 
            {

                IdAutoGenerado = 0;
            }

            return IdAutoGenerado;
        }

        public async Task<bool> EditarConcepto(Concepto concepto)
        {
            bool resultado = false;

            try
            {
                concepto.total = concepto.cantidad * concepto.precioUnitario;

                context.Concepto.AddOrUpdate(concepto);
                await context.SaveChangesAsync();
                resultado = true;

            }
            catch (Exception ex)
            {
                resultado = false;
                throw new Exception(ex.Message);
            }

            return resultado;

        }

        public async Task<bool> EliminarConcepto(int Id)
        {
            try
            {
                var conceptoEliminar = await GetConcepto(Id);
                context.Concepto.Remove(conceptoEliminar);
                await context.SaveChangesAsync();
                return true;
            }
            catch 
            {
                return false;
            }
        }       
    }
}
