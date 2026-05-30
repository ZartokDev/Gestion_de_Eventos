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
    public class InventariosModel : PageModel
    {
        private IInventariosNegocioP iInventariosNegocio;
        private IProveedoresNegocioP iProveedoresNegocio;
        private ITipoInventariosNegocioP iTipoInventariosNegocio;
        [BindProperty] public List<Inventarios>? Lista { get; set; }
        [BindProperty] public Inventarios? Inventario { get; set; }
        [BindProperty] public List<Proveedores>? ListaProveedores { get; set; }
        [BindProperty] public List<TipoInventarios>? ListaTipoInventarios { get; set; }
        [BindProperty] public bool Borrando { get; set; }
 
        public InventariosModel() 
        {
            iInventariosNegocio = new InventariosNegocioP();
            iProveedoresNegocio = new ProveedoresNegocioP();
            iTipoInventariosNegocio = new TipoInventariosNegocioP();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
          

        }

        public virtual void CargarRelaciones()
        {
            ListaProveedores = iProveedoresNegocio.Consultar();
            ListaTipoInventarios = iTipoInventariosNegocio.Consultar();
        }

        public void OnPostBtRefrescar()
        {
            try
            {
                CargarRelaciones();
                if (iInventariosNegocio == null)
                    return;
                Lista = iInventariosNegocio.Consultar();
                Inventario = null;
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
                Inventario = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (Inventario == null)
                    return;

                Inventario = iInventariosNegocio!.Eliminar(Inventario!);
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
                if (Inventario == null) 
                    return;
                if (Inventario.Id == 0)
                    Inventario = iInventariosNegocio!.Guardar(Inventario!);
                else
                {
                    Inventario = iInventariosNegocio!.Modificar(Inventario!);
                }
                if (Inventario.Id == 0)
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
                Inventario = Lista!.FirstOrDefault(x => x.Id == data);
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