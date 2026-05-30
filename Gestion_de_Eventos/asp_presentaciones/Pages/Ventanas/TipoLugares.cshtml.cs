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
    public class TipoLugaresModel : PageModel
    {
        private ITipoLugaresNegocioP iTipoLugaresNegocio;
        [BindProperty] public List<TipoLugares>? Lista { get; set; }
        [BindProperty] public TipoLugares? TipoLugar { get; set; }
        [BindProperty] public bool Borrando { get; set; }
 
        public TipoLugaresModel() 
        {
            iTipoLugaresNegocio = new TipoLugaresNegocioP();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
          

        }
        public void OnPostBtRefrescar()
        {
            try
            {
                if (iTipoLugaresNegocio == null)
                    return;
                Lista = iTipoLugaresNegocio.Consultar();
                TipoLugar = null;
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
                TipoLugar = Lista!.FirstOrDefault(x => x.Id == data);
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