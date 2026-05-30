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
    public class GruposTrabajadoresModel : PageModel
    {
        private IGruposTrabajadoresNegocioP iGruposTrabajadoresNegocio;
        private IGruposNegocioP iGruposNegocio;
        private ITrabajadoresNegocioP iTrabajadoresNegocio;
        [BindProperty] public List<GruposTrabajadores>? Lista { get; set; }
        [BindProperty] public GruposTrabajadores? GrupoTrabajador { get; set; }
        [BindProperty] public List<Grupos> ListaGrupos { get; set; }
        [BindProperty] public List<Trabajadores> ListaTrabajadores { get; set; }
        [BindProperty] public bool Borrando { get; set; }
 
        public GruposTrabajadoresModel() 
        {
            iGruposTrabajadoresNegocio = new GruposTrabajadoresNegocioP();
            iGruposNegocio = new GruposNegocioP();
            iTrabajadoresNegocio = new TrabajadoresNegocioP();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public void CargarRelaciones()
        {
            ListaGrupos = iGruposNegocio.Consultar();
            ListaTrabajadores = iTrabajadoresNegocio.Consultar();
        }
        public void OnPostBtRefrescar()
        {
            try
            {
                CargarRelaciones();
                if (iGruposTrabajadoresNegocio == null)
                    return;
                Lista = iGruposTrabajadoresNegocio.Consultar();
                GrupoTrabajador = null;
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
                GrupoTrabajador = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (GrupoTrabajador == null)
                    return;

                GrupoTrabajador = iGruposTrabajadoresNegocio!.Eliminar(GrupoTrabajador!);
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
                if (GrupoTrabajador == null) 
                    return;
                if (GrupoTrabajador.Id == 0)
                    GrupoTrabajador = iGruposTrabajadoresNegocio!.Guardar(GrupoTrabajador!);
                else
                {
                    GrupoTrabajador = iGruposTrabajadoresNegocio!.Modificar(GrupoTrabajador!);
                }
                if (GrupoTrabajador.Id == 0)
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
                GrupoTrabajador = Lista!.FirstOrDefault(x => x.Id == data);
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