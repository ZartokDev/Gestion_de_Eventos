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
    public class TipoTransportesModel : PageModel
    {
        private ITipoTransportesNegocioP iTipoTransportesNegocio;
        [BindProperty] public List<TipoTransportes>? Lista { get; set; }
        [BindProperty] public TipoTransportes? TipoTransporte { get; set; }
        [BindProperty] public bool Borrando { get; set; }
 
        public TipoTransportesModel() 
        {
            iTipoTransportesNegocio = new TipoTransportesNegocioP();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
          

        }
        public void OnPostBtRefrescar()
        {
            try
            {
                if (iTipoTransportesNegocio == null)
                    return;
                Lista = iTipoTransportesNegocio.Consultar();
                TipoTransporte = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
           
        }

        public void OnPostBtNuevo()
        {
            Borrando = false;
        }

        public void OnPostBtBorrarVal(int data)
        {

            try
            {
                OnPostBtRefrescar();
                TipoTransporte = Lista!.FirstOrDefault(x => x.Id == data);
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