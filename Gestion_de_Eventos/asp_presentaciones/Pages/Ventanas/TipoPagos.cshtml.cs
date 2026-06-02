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
    public class TipoPagosModel : PageModel
    {
        private ITipoPagosNegocioP iTipoPagosNegocio;
        [BindProperty] public List<TipoPagos>? Lista { get; set; }
        [BindProperty] public TipoPagos? TipoPago { get; set; }
        [BindProperty] public bool Borrando { get; set; }
 
        public TipoPagosModel() 
        {
            iTipoPagosNegocio = new TipoPagosNegocioP();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
          

        }
        public void OnPostBtRefrescar()
        {
            try
            {
                if (iTipoPagosNegocio == null)
                    return;
                Lista = iTipoPagosNegocio.Consultar();
                TipoPago = null;
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
                TipoPago = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (TipoPago == null)
                    return;
                TipoPago.Estado = false;
                TipoPago = iTipoPagosNegocio!.Modificar(TipoPago!);
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
                if (TipoPago == null)
                    return;
                if (TipoPago.Id == 0)
                    TipoPago = iTipoPagosNegocio!.Guardar(TipoPago!);
                else
                {
                    TipoPago = iTipoPagosNegocio!.Modificar(TipoPago!);
                }
                if (TipoPago.Id == 0)
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
                TipoPago = Lista!.FirstOrDefault(x => x.Id == data);
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