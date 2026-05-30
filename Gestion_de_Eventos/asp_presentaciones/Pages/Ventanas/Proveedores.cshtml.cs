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
    public class ProveedoresModel : PageModel
    {
        private IProveedoresNegocioP iProveedoresNegocio;
        [BindProperty] public List<Proveedores>? Lista { get; set; }
        [BindProperty] public Proveedores? Proveedor { get; set; }
        [BindProperty] public bool Borrando { get; set; }
 
        public ProveedoresModel() 
        {
            iProveedoresNegocio = new ProveedoresNegocioP();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
          

        }
        public void OnPostBtRefrescar()
        {
            try
            {
                if (iProveedoresNegocio == null)
                    return;
                Lista = iProveedoresNegocio.Consultar();
                Proveedor = null;
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
                Proveedor = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (Proveedor == null)
                    return;

                Proveedor = iProveedoresNegocio!.Eliminar(Proveedor!);
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
                if (Proveedor == null) 
                    return;
                if (Proveedor.Id == 0)
                    Proveedor = iProveedoresNegocio!.Guardar(Proveedor!);
                else
                {
                    Proveedor = iProveedoresNegocio!.Modificar(Proveedor!);
                }
                if (Proveedor.Id == 0)
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
                Proveedor = Lista!.FirstOrDefault(x => x.Id == data);
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