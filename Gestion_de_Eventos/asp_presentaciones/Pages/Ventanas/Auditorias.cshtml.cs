using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;
using lib_eventos.interfaces;

namespace asp_presentaciones.Pages
{
    public class AuditoriasModel : PageModel
    {
        private IAuditoriasNegocioP iAuditoriasNegocio;
        [BindProperty] public List<Auditorias>? Lista { get; set; }
        [BindProperty] public Auditorias? Auditoria { get; set; }
        [BindProperty] public bool Borrando { get; set; }
 
        public AuditoriasModel() 
        {
            iAuditoriasNegocio = new AuditoriasNegocioP();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
          

        }
        public void OnPostBtRefrescar()
        {
            try
            {
                if (iAuditoriasNegocio == null)
                    return;
                Lista = iAuditoriasNegocio.Consultar();
                Auditoria = null;
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