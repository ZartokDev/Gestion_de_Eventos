using lib_eventos.entidades;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace asp_presentaciones.Pages
{
    public class DisponibilidadModel : PageModel
    {
        private ILugaresNegocioP iLugaresNegocio;
        private ITransportesNegocioP iTransportesNegocio;
        private IInventariosNegocioP iInventariosNegocio;
        private IGruposNegocioP iGruposNegocio;
        private IProveedoresNegocioP iProveedoresNegocio;

        public List<Lugares>? ListaLugares { get; set; }
        public List<Transportes>? ListaTransportes { get; set; }
        public List<Inventarios>? ListaInventarios { get; set; }
        public List<Grupos>? ListaGrupos { get; set; }
        public List<Proveedores>? ListaProveedores { get; set; }

        public DisponibilidadModel()
        {
            iLugaresNegocio = new LugaresNegocioP();
            iTransportesNegocio = new TransportesNegocioP();
            iInventariosNegocio = new InventariosNegocioP();
            iGruposNegocio = new GruposNegocioP();
            iProveedoresNegocio = new ProveedoresNegocioP();
        }

        public IActionResult OnGet()
        {
            try
            {
                ListaLugares = iLugaresNegocio.Consultar()?.Where(x => x.Estado).ToList();
                ListaTransportes = iTransportesNegocio.Consultar()?.Where(x => x.Estado).ToList();
                ListaInventarios = iInventariosNegocio.Consultar()?.Where(x => x.EstadoProducto).ToList();
                ListaGrupos = iGruposNegocio.Consultar()?.Where(x => x.Estado).ToList();
                ListaProveedores = iProveedoresNegocio.Consultar()?.Where(x => x.Estado).ToList();
            }
            catch (System.Exception ex)
            {
                ViewData["Mensaje"] = "Error al cargar los catálogos de disponibilidad: " + ex.Message;
            }

            return Page();
        }
    }
}