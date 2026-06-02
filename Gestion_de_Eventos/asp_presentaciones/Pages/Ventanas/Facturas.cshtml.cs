using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace asp_presentaciones.Pages
{
    [Authorize]
    public class FacturasModel : PageModel
    {
        private IFacturasNegocioP iFacturasNegocio;
        private ITipoPagosNegocioP iTipoPagosNegocio;
        private IOfertasNegocioP iOfertasNegocioP;
        private IFacturasNegocioP iFacturasNegocioP;
        private IEventosNegocioP iEventosNegocioP;

        [BindProperty] public List<Facturas>? Lista { get; set; }
        [BindProperty] public Facturas? Factura { get; set; }
        [BindProperty] public List<TipoPagos>? ListaTipoPagos { get; set; }
        [BindProperty] public List<Ofertas>? ListaOfertas { get; set; }
        [BindProperty] public List<Facturas>? ListaFacturas { get; set; }
        [BindProperty] public List<Eventos>? ListaEventos { get; set; }
        [BindProperty] public bool Borrando { get; set; }
 
        public FacturasModel() 
        {
            iFacturasNegocio = new FacturasNegocioP();
            iTipoPagosNegocio = new TipoPagosNegocioP();
            iOfertasNegocioP = new OfertasNegocioP();
            iFacturasNegocioP = new FacturasNegocioP();
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
            ListaFacturas = iFacturasNegocioP.Consultar();
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

        public void OnPostBtBorrar()
        {
            try
            {
                if (Factura == null) return;
                Factura.EstadoPago = false;
                Factura = iFacturasNegocio!.Modificar(Factura!);
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (Factura == null) return;
                if (Factura.Id == 0)
                    Factura = iFacturasNegocio!.Guardar(Factura!);
                else
                    Factura = iFacturasNegocio!.Modificar(Factura!);

                if (Factura.Id == 0) return;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                CargarRelaciones();
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Factura = Lista!.FirstOrDefault(x => x.Id == data);
                Lista = null;
                Borrando = false;
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