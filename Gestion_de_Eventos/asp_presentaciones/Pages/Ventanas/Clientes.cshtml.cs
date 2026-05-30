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
    public class ClientesModel : PageModel
    {
        private IClientesNegocioP iClientesNegocio;
        [BindProperty] public List<Clientes>? Lista { get; set; }
        [BindProperty] public Clientes? Cliente { get; set; }
        [BindProperty] public bool Borrando { get; set; }
 
        public ClientesModel() 
        {
            iClientesNegocio = new ClientesNegocioP();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
          

        }
        public void OnPostBtRefrescar()
        {
            try
            {
                if (iClientesNegocio == null)
                    return;
                Lista = iClientesNegocio.Consultar();
                Cliente = null;
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
                Cliente = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (Cliente == null)
                    return;

                Cliente = iClientesNegocio!.Eliminar(Cliente!);
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
                if (Cliente == null) 
                    return;
                if (Cliente.Id == 0)
                    Cliente = iClientesNegocio!.Guardar(Cliente!);
                else
                {
                    Cliente = iClientesNegocio!.Modificar(Cliente!);
                }
                if (Cliente.Id == 0)
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
                Cliente = Lista!.FirstOrDefault(x => x.Id == data);
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