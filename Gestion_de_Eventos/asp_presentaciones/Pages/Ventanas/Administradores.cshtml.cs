using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace asp_presentaciones.Pages
{
    public class AdministradoresModel : PageModel
    {
        private IAdministradoresNegocioP iAdministradoresNegocio;
        [BindProperty] public List<Administradores>? Lista { get; set; }
        [BindProperty] public Administradores? Administrador { get; set; }
        [BindProperty] public bool Borrando { get; set; }
 
        public AdministradoresModel() 
        {
            iAdministradoresNegocio = new AdministradoresNegocioP();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
          

        }
        public void OnPostBtRefrescar()
        {
            try
            {
                if (iAdministradoresNegocio == null)
                    return;
                Lista = iAdministradoresNegocio.Consultar();
                Administrador = null;
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
                Administrador = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (Administrador == null)
                    return;

                Administrador = iAdministradoresNegocio!.Eliminar(Administrador!);
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
                if (Administrador == null) 
                    return;
                if (Administrador.Id == 0)
                    Administrador = iAdministradoresNegocio!.Guardar(Administrador!);
                else
                {
                    Administrador = iAdministradoresNegocio!.Modificar(Administrador!);
                }
                if (Administrador.Id == 0)
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
                Administrador = Lista!.FirstOrDefault(x => x.Id == data);
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