using AutoMapper;
using CapaEntidad;
using CapaEntidad.ViewModel;
using CapaNegocio;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MaestroDetalle.Controllers
{
    public class VentaController : Controller
    {
        private CnUnitOfWork repositorios = new CnUnitOfWork(new SistemaVentaEntities());

        // GET: Venta
        public ActionResult Ventas()
        {
            return View();
        }

        public async Task<JsonResult> ListarVentas()
        {
            var modelEnviar = new List<VentaViewModel>();
            var modelRecibido = await repositorios.repoVenta().GetVentas();

            modelEnviar = (from d in modelRecibido
                           select new VentaViewModel
                           {
                               idVenta = d.idVenta,
                               fecha = d.fecha.Date,
                               Cliente = new ClienteViewModel
                               {
                                   nombre = d.Cliente.nombre,
                                   telefono = d.Cliente.telefono
                               }
                           }).ToList();

            return Json(new { data = modelEnviar }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> DetalleVenta(int Id=0)
        {            
            var modelRecibido = await repositorios.repoVenta().GetVenta(Id);


            var modelEnviar = new VentaViewModel
            {
                idVenta = modelRecibido.idVenta,
                fecha = modelRecibido.fecha,
                Cliente = new ClienteViewModel
                {
                    nombre = modelRecibido.Cliente.nombre,
                    telefono = modelRecibido.Cliente.telefono,
                    email = modelRecibido.Cliente.email
                }
            };
           

            return View(modelEnviar);
        }

        public async Task<JsonResult> ListarConceptosVenta(int Id)
        {
            var modelRecibido = await repositorios.repoVenta().GetVentaConceptos(Id);
            var modelEnviar = Mapper.Map<List<ConceptoViewModel>>(modelRecibido);

            return Json(new { data = modelEnviar }, JsonRequestBehavior.AllowGet);
        } 
         
        [HttpPost]
        public async Task<JsonResult> EliminarVenta(int Id = 0)
        {
            bool respuestaEnviar = await repositorios.repoVenta().EliminarVenta(Id);

            return Json(new { resultado = respuestaEnviar }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> InsertarVentaConcepto()
        {
            var cliente = await repositorios.repoCliente().GetClientes();

            return View(cliente);
        }

        public async Task<ActionResult> GuardarVentaConcepto(ClienteVentaViewModel model)
        {
            var modelEnviar = new ClienteVentaConcepto();

            modelEnviar.OneVenta = new Venta() { idCliente = model.OneVenta.idCliente };

            modelEnviar.Concepto = Mapper.Map<List<Concepto>>(model.Concepto);

            await repositorios.repoVenta().InsertarVentaConcepto(modelEnviar);

            return Redirect("InsertarVentaConcepto");
        }
    }
}