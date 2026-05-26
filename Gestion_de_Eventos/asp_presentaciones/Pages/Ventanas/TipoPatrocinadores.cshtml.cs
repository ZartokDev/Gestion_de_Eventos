using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace asp_presentaciones.Pages
{
    public class TipoPatrocinadoresModel : PageModel
    {
        private ITipoPatrocinadoresNegocioP iTipoPatrocinadoresNegocio;
        [BindProperty] public List<TipoPatrocinadores>? Lista { get; set; }
        [BindProperty] public TipoPatrocinadores? TipoPatrocinador { get; set; }
        [BindProperty] public bool Borrando { get; set; }
 
        public TipoPatrocinadoresModel() 
        {
            iTipoPatrocinadoresNegocio = new TipoPatrocinadoresNegocioP();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
          

        }
        public void OnPostBtRefrescar()
        {
            try
            {
                if (iTipoPatrocinadoresNegocio == null)
                    return;
                Lista = iTipoPatrocinadoresNegocio.Consultar();
                TipoPatrocinador = null;
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

        public void OnPostBtCerrar() 
        {
            OnPostBtRefrescar();
            Borrando = false;
        }

    }
}