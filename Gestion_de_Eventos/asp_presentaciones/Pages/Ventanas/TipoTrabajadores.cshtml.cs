using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace asp_presentaciones.Pages
{
    public class TipoTrabajadoresModel : PageModel
    {
        private ITipoTrabajadoresNegocioP iTipoTrabajadoresNegocio;
        [BindProperty] public List<TipoTrabajadores>? Lista { get; set; }
        [BindProperty] public TipoTrabajadores? TipoTrabajador { get; set; }
        [BindProperty] public bool Borrando { get; set; }
 
        public TipoTrabajadoresModel() 
        {
            iTipoTrabajadoresNegocio = new TipoTrabajadoresNegocioP();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
          

        }
        public void OnPostBtRefrescar()
        {
            try
            {
                if (iTipoTrabajadoresNegocio == null)
                    return;
                Lista = iTipoTrabajadoresNegocio.Consultar();
                TipoTrabajador = null;
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