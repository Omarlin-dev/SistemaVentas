using CapaEntidad;

namespace CapaNegocio
{
    public class CnUnitOfWork
    {
        private readonly CnCliente cliente;
        private readonly CnConcepto concepto;
        private readonly CnVenta venta;
        public readonly SistemaVentaEntities context;

        public CnUnitOfWork(SistemaVentaEntities context)
        {
            cliente = cliente ?? new CnCliente(context);
            concepto = concepto ?? new CnConcepto(context);
            venta = venta ?? new CnVenta(context);
            this.context = context;
        }

        public CnCliente repoCliente()
        {
            return cliente;
        }
        public CnConcepto repoConceto()
        {
            return concepto;
        }
        
        public CnVenta repoVenta()
        {
            return venta;
        }

    }
}
