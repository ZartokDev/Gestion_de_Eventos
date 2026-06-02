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

        public void OnPostBtBorrarVal(int data)
        {

            try
            {
                OnPostBtRefrescar();
                TipoPatrocinador = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (TipoPatrocinador == null)
                    return;
                TipoPatrocinador.Estado = false;
                TipoPatrocinador = iTipoPatrocinadoresNegocio!.Modificar(TipoPatrocinador!);
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
                if (TipoPatrocinador == null)
                    return;
                if (TipoPatrocinador.Id == 0)
                    TipoPatrocinador = iTipoPatrocinadoresNegocio!.Guardar(TipoPatrocinador!);
                else
                {
                    TipoPatrocinador = iTipoPatrocinadoresNegocio!.Modificar(TipoPatrocinador!);
                }
                if (TipoPatrocinador.Id == 0)
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
                TipoPatrocinador = Lista!.FirstOrDefault(x => x.Id == data);
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