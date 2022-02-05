using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Interfaces
{ 
    public interface IConceptoClienteRepositorio
    {
        Task<Concepto> GetConcepto(int Id);
        Task<int> InsertarConcepto(Concepto concepto);
        Task<bool> EditarConcepto(Concepto concepto); 
        Task<bool> EliminarConcepto(int Id);
    }
}
