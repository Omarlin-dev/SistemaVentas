using CapaDatos.Repositorios;
using CapaEntidad;
using System;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CnConcepto
    {
        private readonly repoUnitOfWork repositorios;

        public CnConcepto(SistemaVentaEntities context)
        {
            repositorios = new repoUnitOfWork(context);
        }

        public async Task<int> InsertarConcepto(Concepto concepto)
        {
            return await repositorios.repoConcetoCliente().InsertarConcepto(concepto);
        }

        public async Task<bool> EditarConcepto(Concepto concepto)
        {
            try
            {
                var existeConcepto = await repositorios.repoConcetoCliente().GetConcepto(concepto.idConcepto);

                if (concepto.idConcepto != 0)
                {
                    if(existeConcepto != null)
                    {
                        return await repositorios.repoConcetoCliente().EditarConcepto(concepto);
                    }
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> EliminarConcepto(int Id)
        {
            try
            {
                var existeConcepto = await repositorios.repoConcetoCliente().GetConcepto(Id);
                
                var comprobarVentaConcepto = await repositorios.repoCoceptoVenta().GetVenta(existeConcepto.idVenta);

                if (Id != 0)
                {
                    if(existeConcepto != null)
                    {
                        if (comprobarVentaConcepto != null)
                        {
                            return await repositorios.repoConcetoCliente().EliminarConcepto(Id);
                        }
                    }                   
                }
                 
                return false;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
