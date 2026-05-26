using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace asp_presentaciones.Pages
{
    public class TipoEventosModel : PageModel
    {
        private ITipoEventosNegocioP iTipoEventosNegocio;
        [BindProperty] public List<TipoEventos>? Lista { get; set; }
        [BindProperty] public TipoEventos? TipoEvento { get; set; }
        [BindProperty] public bool Borrando { get; set; }
 
        public TipoEventosModel() 
        {
            iTipoEventosNegocio = new TipoEventosNegocioP();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
          

        }
        public void OnPostBtRefrescar()
        {
            try
            {
                if (iTipoEventosNegocio == null)
                    return;
                Lista = iTipoEventosNegocio.Consultar();
                TipoEvento = null;
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
                TipoEvento = Lista!.FirstOrDefault(x => x.Id == data);
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