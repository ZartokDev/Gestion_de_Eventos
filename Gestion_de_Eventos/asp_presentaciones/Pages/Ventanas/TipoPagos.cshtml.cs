using lib_eventos.entidades;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace asp_presentaciones.Pages
{
    [Authorize]
    public class TipoPagosModel : PageModel
    {
        private ITipoPagosNegocioP iTipoPagosNegocio;
        [BindProperty] public List<TipoPagos>? Lista { get; set; }
        [BindProperty] public TipoPagos? TipoPago { get; set; }
        [BindProperty] public bool Borrando { get; set; }
 
        public TipoPagosModel() 
        {
            iTipoPagosNegocio = new TipoPagosNegocioP();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
          

        }
        public void OnPostBtRefrescar()
        {
            try
            {
                if (iTipoPagosNegocio == null)
                    return;
                Lista = iTipoPagosNegocio.Consultar();
                TipoPago = null;
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