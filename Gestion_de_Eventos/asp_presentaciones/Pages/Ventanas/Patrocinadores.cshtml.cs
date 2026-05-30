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
    public class PatrocinadoresModel : PageModel
    {
        private IPatrocinadoresNegocioP iPatrocinadoresNegocio;
        private ITipoPatrocinadoresNegocioP iTipoPatrocinadoresNegocio;
        [BindProperty] public List<Patrocinadores>? Lista { get; set; }
        [BindProperty] public Patrocinadores? Patrocinador { get; set; }
        [BindProperty] public List<TipoPatrocinadores>? ListaTipoPatrocinadores { get; set; }
        [BindProperty] public bool Borrando { get; set; }
 
        public PatrocinadoresModel() 
        {
            iPatrocinadoresNegocio = new PatrocinadoresNegocioP();
            iTipoPatrocinadoresNegocio = new TipoPatrocinadoresNegocioP();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
          

        }

        public void CargarRelaciones()
        {
            ListaTipoPatrocinadores = iTipoPatrocinadoresNegocio.Consultar();
        }
        public void OnPostBtRefrescar()
        {
            try
            {
                CargarRelaciones();
                if (iPatrocinadoresNegocio == null)
                    return;
                Lista = iPatrocinadoresNegocio.Consultar();
                Patrocinador = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
           
        }

        public void OnPostBtNuevo()
        {
            CargarRelaciones();
            Borrando = false;
        }

        public void OnPostBtBorrarVal(int data)
        {

            try
            {
                OnPostBtRefrescar();
                Patrocinador = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (Patrocinador == null)
                    return;

                Patrocinador = iPatrocinadoresNegocio!.Eliminar(Patrocinador!);
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
                if (Patrocinador == null) 
                    return;
                if (Patrocinador.Id == 0)
                    Patrocinador = iPatrocinadoresNegocio!.Guardar(Patrocinador!);
                else
                {
                    Patrocinador = iPatrocinadoresNegocio!.Modificar(Patrocinador!);
                }
                if (Patrocinador.Id == 0)
                    return;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                CargarRelaciones();
                ViewData["Mensaje"] = ex.Message;
            }
            
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Patrocinador = Lista!.FirstOrDefault(x => x.Id == data);
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