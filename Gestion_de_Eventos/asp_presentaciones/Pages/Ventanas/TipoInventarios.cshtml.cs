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

        public void OnPostBtBorrar()
        {
            try
            {
                if (TipoInventario == null)
                    return;
                TipoInventario.Estado = false;
                TipoInventario = iTipoInventariosNegocio!.Modificar(TipoInventario!);
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
                if (TipoInventario == null)
                    return;
                if (TipoInventario.Id == 0)
                    TipoInventario = iTipoInventariosNegocio!.Guardar(TipoInventario!);
                else
                {
                    TipoInventario = iTipoInventariosNegocio!.Modificar(TipoInventario!);
                }
                if (TipoInventario.Id == 0)
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
                TipoInventario = Lista!.FirstOrDefault(x => x.Id == data);
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