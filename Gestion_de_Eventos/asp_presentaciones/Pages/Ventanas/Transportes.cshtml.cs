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
    public class TransportesModel : PageModel
    {
        private ITransportesNegocioP iTransportesNegocio;
        private ITipoTransportesNegocioP iTipoTransportesNegocio;
        [BindProperty] public List<Transportes>? Lista { get; set; }
        [BindProperty] public Transportes? Transporte { get; set; }
        [BindProperty] public List<TipoTransportes>? ListaTipoTransportes { get; set; }
        [BindProperty] public bool Borrando { get; set; }
 
        public TransportesModel() 
        {
            iTransportesNegocio = new TransportesNegocioP();
            iTipoTransportesNegocio = new TipoTransportesNegocioP();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
          

        }

        public void CargarRelaciones()
        {
            ListaTipoTransportes = iTipoTransportesNegocio.Consultar();
        }
        public void OnPostBtRefrescar()
        {
            try
            {
                CargarRelaciones();
                if (iTransportesNegocio == null)
                    return;
                Lista = iTransportesNegocio.Consultar();
                Transporte = null;
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
                Transporte = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (Transporte == null)
                    return;

                Transporte = iTransportesNegocio!.Eliminar(Transporte!);
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
                if (Transporte == null) 
                    return;
                if (Transporte.Id == 0)
                    Transporte = iTransportesNegocio!.Guardar(Transporte!);
                else
                {
                    Transporte = iTransportesNegocio!.Modificar(Transporte!);
                }
                if (Transporte.Id == 0)
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
                Transporte = Lista!.FirstOrDefault(x => x.Id == data);
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