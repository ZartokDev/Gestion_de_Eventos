using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace asp_presentaciones.Pages
{
    public class FacturasModel : PageModel
    {
        private IFacturasNegocioP iFacturasNegocio;
        [BindProperty] public List<Facturas>? Lista { get; set; }
        [BindProperty] public Facturas? Factura { get; set; }
        [BindProperty] public bool Borrando { get; set; }
 
        public FacturasModel() 
        {
            iFacturasNegocio = new FacturasNegocioP();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
          

        }
        public void OnPostBtRefrescar()
        {
            try
            {
                if (iFacturasNegocio == null)
                    return;
                Lista = iFacturasNegocio.Consultar();
                Factura = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
           
        }

        public void OnPostBtNuevo()
        {
            Factura = new Facturas()
            {
                FechaEmision = DateTime.Now
            };
            Borrando = false;
        }

        public void OnPostBtBorrarVal(int data)
        {

            try
            {
                OnPostBtRefrescar();
                Factura = Lista!.FirstOrDefault(x => x.Id == data);
                Lista = null;
                Borrando = true;

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