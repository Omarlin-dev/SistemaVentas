using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using CapaEntidad;
using CapaEntidad.ViewModel;

namespace MaestroDetalle.ConfigMapper
{
    public class AutomapperConfig: Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<ClienteViewModel, Cliente>();

            CreateMap<Venta, VentaViewModel>();
            CreateMap<VentaViewModel, Venta>();

            CreateMap<Concepto, ConceptoViewModel>();
            CreateMap<ConceptoViewModel, Concepto>();
        }
    }
}