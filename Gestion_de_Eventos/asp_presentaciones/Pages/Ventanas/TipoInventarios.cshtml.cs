using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace asp_presentaciones.Pages
{
    public class TipoInventariosModel : PageModel
    {
        private ITipoInventariosNegocioP iTipoInventariosNegocio;
        [BindProperty] public List<TipoInventarios>? Lista { get; set; }
        [BindProperty] public TipoInventarios? TipoInventario { get; set; }
        [BindProperty] public bool Borrando { get; set; }
 
        public TipoInventariosModel() 
        {
            iTipoInventariosNegocio = new TipoInventariosNegocioP();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
          

        }
        public void OnPostBtRefrescar()
        {
            try
            {
                if (iTipoInventariosNegocio == null)
                    return;
                Lista = iTipoInventariosNegocio.Consultar();
                TipoInventario = null;
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
                TipoInventario = Lista!.FirstOrDefault(x => x.Id == data);
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