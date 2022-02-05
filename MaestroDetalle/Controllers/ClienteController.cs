using CapaNegocio;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using CapaEntidad;
using CapaEntidad.ViewModel;
using System.Collections.Generic;
using System.Data.Entity;

namespace MaestroDetalle.Controllers
{
    public class ClienteController : Controller
    {
        private readonly CnUnitOfWork repositorio = new CnUnitOfWork(new SistemaVentaEntities());

        // GET: Cliente
        public ActionResult Cliente()
        {
            return View();
        }

        public async Task<JsonResult> ListarClientes()
        {
            var clientes = await repositorio.repoCliente().GetClientes();
            var clienteData = Mapper.Map<List<ClienteViewModel>>(clientes);

            return Json(new { data = clienteData }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Detalle(int Id)
        {
            var clienteRecibir = await repositorio.repoCliente().GetCliente(Id);
            var clienteTotalEnviar = new ClienteVentaViewModel();
            clienteTotalEnviar.Cliente = Mapper.Map<ClienteViewModel>(clienteRecibir.Cliente);
            clienteTotalEnviar.total = clienteRecibir.total;

            return View(clienteTotalEnviar);
        }

        public async Task<JsonResult> ListarDetalleConceptos(int Id)
        {
            var conceptosClientes = await repositorio.repoCliente().GetClienteConceptos(Id);
            var modelEnviar = Mapper.Map<List<ConceptoViewModel>>(conceptosClientes);

            return Json(new { data = modelEnviar }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> GuardarCliente(ClienteViewModel clienteModel)
        {
            object jsonEnviar;

            var clienteMapeado = Mapper.Map<Cliente>(clienteModel);

            if (clienteModel.idCliente == 0)
            {
                jsonEnviar = await repositorio.repoCliente().InsertarCliente(clienteMapeado);
            }
            else
            {
                jsonEnviar = await repositorio.repoCliente().EditarCliente(clienteMapeado);
            }

            return Json(new { resultado = jsonEnviar }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> EliminarCliente(int Id= 0)
        {
            bool jsonEnviar = await repositorio.repoCliente().EliminarCliente(Id);

            return Json(new { resultado = jsonEnviar }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public async Task<JsonResult> GuardarConceptosCliente(ConceptoViewModel conceptoModel)
        {
            object jsonEnviar;
            var conceptoEnviar = Mapper.Map<Concepto>(conceptoModel);           

            if (conceptoModel.idConcepto == 0)
            {
                var venta = await repositorio.context.Venta.FirstOrDefaultAsync(x => x.idCliente == conceptoModel.idCliente);

                conceptoEnviar.idVenta = venta.idVenta;

                jsonEnviar = await repositorio.repoConceto().InsertarConcepto(conceptoEnviar);
            }
            else
            { 
                jsonEnviar = await repositorio.repoConceto().EditarConcepto(conceptoEnviar);
            }

            return Json(new { resultado = jsonEnviar }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<JsonResult> EliminarConcepto(int Id = 0)
        {
            bool jsonEnviar = await repositorio.repoConceto().EliminarConcepto(Id);

            return Json(new { resultado = jsonEnviar }, JsonRequestBehavior.AllowGet);
        }
    }
}