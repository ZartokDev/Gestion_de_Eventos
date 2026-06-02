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

        public void OnPostBtBorrar()
        {
            try
            {
                if (TipoEvento == null)
                    return;
                TipoEvento.Estado = false;
                TipoEvento = iTipoEventosNegocio!.Modificar(TipoEvento!);
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
                if (TipoEvento == null)
                    return;
                if (TipoEvento.Id == 0)
                    TipoEvento = iTipoEventosNegocio!.Guardar(TipoEvento!);
                else
                {
                    TipoEvento = iTipoEventosNegocio!.Modificar(TipoEvento!);
                }
                if (TipoEvento.Id == 0)
                    return;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }

        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                TipoEvento = Lista!.FirstOrDefault(x => x.Id == data);
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