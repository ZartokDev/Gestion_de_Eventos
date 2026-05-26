using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace asp_presentaciones.Pages
{
    public class HorariosModel : PageModel
    {
        private IHorariosNegocioP iHorariosNegocio;
        [BindProperty] public List<Horarios>? Lista { get; set; }
        [BindProperty] public Horarios? Horario { get; set; }
        [BindProperty] public bool Borrando { get; set; }
 
        public HorariosModel() 
        {
            iHorariosNegocio = new HorariosNegocioP();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
          

        }
        public void OnPostBtRefrescar()
        {
            try
            {
                if (iHorariosNegocio == null)
                    return;
                Lista = iHorariosNegocio.Consultar();
                Horario = null;
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
                Horario = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (Horario == null)
                    return;

                Horario = iHorariosNegocio!.Eliminar(Horario!);
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
                if (Horario == null) 
                    return;
                if (Horario.Id == 0)
                    Horario = iHorariosNegocio!.Guardar(Horario!);
                else
                {
                    Horario = iHorariosNegocio!.Modificar(Horario!);
                }
                if (Horario.Id == 0)
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
                Horario = Lista!.FirstOrDefault(x => x.Id == data);
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