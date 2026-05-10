using lib_eventos.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;

namespace asp_presentaciones.Pages
{
    public class EventosModel : PageModel
    {
        [BindProperty] public List<Eventos>? Lista { get; set; }

        public void OnGet()
        {
            IEventosNegocioP iEventosNegocio = new EventosNegocioP();
            Lista = iEventosNegocio.Consultar();
        }
    }
}