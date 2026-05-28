using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace asp_presentaciones.Pages
{
    public class LugaresModel : PageModel
    {
        private ILugaresNegocioP iLugaresNegocio;
        private ITipoLugaresNegocioP iTipoLugaresNegocio;
        [BindProperty] public List<Lugares>? Lista { get; set; }
        [BindProperty] public Lugares? Lugar { get; set; }
        [BindProperty] public List<TipoLugares>? ListaTipoLugares { get; set; }


        [BindProperty] public bool Borrando { get; set; }
 
        public LugaresModel() 
        {
            iLugaresNegocio = new LugaresNegocioP();
            iTipoLugaresNegocio = new TipoLugaresNegocioP();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();


        }

        public void CargarRelaciones()
        {
            ListaTipoLugares = iTipoLugaresNegocio.Consultar();
        }
        public void OnPostBtRefrescar()
        {
            try
            {
                CargarRelaciones();
                if (iLugaresNegocio == null)
                    return;
                Lista = iLugaresNegocio.Consultar();
                Lugar = null;
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
                Lugar = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (Lugar == null)
                    return;

                Lugar = iLugaresNegocio!.Eliminar(Lugar!);
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
                if (Lugar == null) 
                    return;
                if (Lugar.Id == 0)
                    Lugar = iLugaresNegocio!.Guardar(Lugar!);
                else
                {
                    Lugar = iLugaresNegocio!.Modificar(Lugar!);
                }
                if (Lugar.Id == 0)
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
                Lugar = Lista!.FirstOrDefault(x => x.Id == data);
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