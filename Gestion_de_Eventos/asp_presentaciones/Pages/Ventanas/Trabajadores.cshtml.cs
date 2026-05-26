using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace asp_presentaciones.Pages
{
    public class TrabajadoresModel : PageModel
    {
        private ITrabajadoresNegocioP iTrabajadoresNegocio;
        [BindProperty] public List<Trabajadores>? Lista { get; set; }
        [BindProperty] public Trabajadores? Trabajador { get; set; }
        [BindProperty] public bool Borrando { get; set; }
 
        public TrabajadoresModel() 
        {
            iTrabajadoresNegocio = new TrabajadoresNegocioP();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
          

        }
        public void OnPostBtRefrescar()
        {
            try
            {
                if (iTrabajadoresNegocio == null)
                    return;
                Lista = iTrabajadoresNegocio.Consultar();
                Trabajador = null;
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
                Trabajador = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (Trabajador == null)
                    return;

                Trabajador = iTrabajadoresNegocio!.Eliminar(Trabajador!);
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
                if (Trabajador == null) 
                    return;
                if (Trabajador.Id == 0)
                    Trabajador = iTrabajadoresNegocio!.Guardar(Trabajador!);
                else
                {
                    Trabajador = iTrabajadoresNegocio!.Modificar(Trabajador!);
                }
                if (Trabajador.Id == 0)
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
                Trabajador = Lista!.FirstOrDefault(x => x.Id == data);
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