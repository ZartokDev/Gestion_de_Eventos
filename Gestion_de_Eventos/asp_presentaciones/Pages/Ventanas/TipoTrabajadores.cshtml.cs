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

        public void OnPostBtNuevo()
        {
            Borrando = false;
        }

        public void OnPostBtBorrarVal(int data)
        {

            try
            {
                OnPostBtRefrescar();
                TipoTrabajador = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (TipoTrabajador == null)
                    return;
                TipoTrabajador.Estado = false;
                TipoTrabajador = iTipoTrabajadoresNegocio!.Modificar(TipoTrabajador!);
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
                if (TipoTrabajador == null)
                    return;
                if (TipoTrabajador.Id == 0)
                    TipoTrabajador = iTipoTrabajadoresNegocio!.Guardar(TipoTrabajador!);
                else
                {
                    TipoTrabajador = iTipoTrabajadoresNegocio!.Modificar(TipoTrabajador!);
                }
                if (TipoTrabajador.Id == 0)
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
                TipoTrabajador = Lista!.FirstOrDefault(x => x.Id == data);
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