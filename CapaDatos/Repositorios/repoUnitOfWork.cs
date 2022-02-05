using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos.Repositorios
{
    public class repoUnitOfWork
    {
        private readonly ClienteRepositorio cliente;
        private readonly ConceptoClienteRepositorio concepto;
        private readonly VentaConceptoRepositorio venta;


        public repoUnitOfWork(SistemaVentaEntities context)
        {
            cliente = cliente ?? new ClienteRepositorio(context);
            concepto = concepto ?? new ConceptoClienteRepositorio(context);
            venta = venta ?? new VentaConceptoRepositorio(context);
        }

        public ClienteRepositorio repoCliente()
        {
            return cliente;
        }
        public ConceptoClienteRepositorio repoConcetoCliente()
        {
            return concepto;
        }

        public VentaConceptoRepositorio repoCoceptoVenta()
        {
            return venta;
        }
    }
}
