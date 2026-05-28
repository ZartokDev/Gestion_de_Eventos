using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace asp_presentaciones.Pages
{
    public class FacturasModel : PageModel
    {
        private IFacturasNegocioP iFacturasNegocio;
        private ITipoPagosNegocioP iTipoPagosNegocio;
        private IOfertasNegocioP iOfertasNegocioP;
        private IEventosNegocioP iEventosNegocioP;

        [BindProperty] public List<Facturas>? Lista { get; set; }
        [BindProperty] public Facturas? Factura { get; set; }
        [BindProperty] public List<TipoPagos>? ListaTipoPagos { get; set; }
        [BindProperty] public List<Ofertas>? ListaOfertas { get; set; }
        [BindProperty] public List<Eventos>? ListaEventos { get; set; }
        [BindProperty] public bool Borrando { get; set; }
 
        public FacturasModel() 
        {
            iFacturasNegocio = new FacturasNegocioP();
            iTipoPagosNegocio = new TipoPagosNegocioP();
            iOfertasNegocioP = new OfertasNegocioP();
            iEventosNegocioP = new EventosNegocioP();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
          

        }

        public void CargarRelaciones()
        {
            ListaTipoPagos = iTipoPagosNegocio.Consultar();
            ListaOfertas = iOfertasNegocioP.Consultar();
            ListaEventos = iEventosNegocioP.Consultar();
        }
        public void OnPostBtRefrescar()
        {
            try
            {
                CargarRelaciones();
                if (iFacturasNegocio == null)
                    return;
                Lista = iFacturasNegocio.Consultar();
                Factura = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
           
        }

        public void OnPostBtNuevo()
        {
            CargarRelaciones();
            Factura = new Facturas()
            {
                FechaEmision = DateTime.Now
            };

            Borrando = false;
        }

        public void OnPostBtBorrarVal(int data)
        {

            try
            {
                OnPostBtRefrescar();
                Factura = Lista!.FirstOrDefault(x => x.Id == data);
                Lista = null;
                Borrando = true;

            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
            
        }

        
        public void OnPostBtCerrar() 
        {
            OnPostBtRefrescar();
            Borrando = false;
        }

    }
}