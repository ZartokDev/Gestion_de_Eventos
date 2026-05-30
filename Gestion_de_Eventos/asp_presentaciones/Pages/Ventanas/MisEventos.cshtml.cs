using lib_eventos.entidades;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace asp_presentaciones.Pages
{
    public class MisEventosModel : PageModel
    {
        private IEventosNegocioP iEventos;
        private ILugaresNegocioP iLugares;
        private IClientesNegocioP iClientes;

        public List<Eventos> ListaMisEventos { get; set; } = new List<Eventos>();
        public List<Lugares> ListaLugares { get; set; } = new List<Lugares>();
        public Clientes ClienteEncontrado { get; set; }

        [BindProperty]
        public string DocumentoInput { get; set; }

        public bool BusquedaRealizada { get; set; } = false;

        public MisEventosModel()
        {
            iEventos = new EventosNegocioP();
            iLugares = new LugaresNegocioP();
            iClientes = new ClientesNegocioP();
        }

        public void OnGet()
        {
            BusquedaRealizada = false;
        }

        public void OnPostBuscar()
        {
            BusquedaRealizada = true;

            if (string.IsNullOrEmpty(DocumentoInput))
            {
                return;
            }

            var todosClientes = iClientes.Consultar() ?? new List<Clientes>();
            ClienteEncontrado = todosClientes.FirstOrDefault(c => c.Documento == DocumentoInput.Trim());

            if (ClienteEncontrado != null)
            {
                ListaLugares = iLugares.Consultar() ?? new List<Lugares>();

                ListaMisEventos = (iEventos.Consultar() ?? new List<Eventos>())
                    .Where(e => e.Cliente == ClienteEncontrado.Id)
                    .OrderBy(e => e.Fecha)
                    .ToList();
            }
        }
    }
}