using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace asp_presentaciones.Pages
{
    public class TipoAdministradoresModel : PageModel
    {
        private ITipoAdministradoresNegocioP iTipoAdministradoresNegocio;
        [BindProperty] public List<TipoAdministradores>? Lista { get; set; }
        [BindProperty] public TipoAdministradores? TipoAdministrador { get; set; }
        [BindProperty] public bool Borrando { get; set; }
 
        public TipoAdministradoresModel() 
        {
            iTipoAdministradoresNegocio = new TipoAdministradoresNegocioP();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
          

        }
        public void OnPostBtRefrescar()
        {
            try
            {
                if (iTipoAdministradoresNegocio == null)
                    return;
                Lista = iTipoAdministradoresNegocio.Consultar();
                TipoAdministrador = null;
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
                TipoAdministrador = Lista!.FirstOrDefault(x => x.Id == data);
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