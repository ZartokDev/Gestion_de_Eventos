using lib_eventos.entidades;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_presentaciones.Pages
{
    public class EventosModel : PageModel
    {
        private IEventosNegocioP iEventosNegocio;
        private ILugaresNegocioP iLugaresNegocio;
        private IClientesNegocioP iClientesNegocio;
        private IHorariosNegocioP iHorariosNegocio;
        private ITipoEventosNegocioP iTipoEventosNegocio;
        private IInventariosNegocioP iInventariosNegocio;
        private IGruposNegocioP iGruposNegocio;
        private IPatrocinadoresNegocioP iPatrocinadoresNegocio;
        private IAdministradoresNegocioP iAdministradoresNegocio;
        private IReservasNegocioP iReservasNegocio;

        // TODO: Inyectar o instanciar tus capas de negocio para las relaciones
        // Ejemplo: private ILugaresNegocio iLugaresNegocio = new LugaresNegocio();

        [BindProperty] public List<Eventos>? Lista { get; set; }
        [BindProperty] public Eventos? Evento { get; set; }
        [BindProperty] public List<Lugares>? ListaLugares { get; set; }
        [BindProperty] public List<Clientes>? ListaClientes { get; set; }
        [BindProperty] public List<Horarios>? ListaHorarios { get; set; }
        [BindProperty] public List<TipoEventos>? ListaTipoEventos { get; set; }
        [BindProperty] public List<Inventarios>? ListaInventarios { get; set; }
        [BindProperty] public List<Grupos>? ListaGrupos { get; set; }
        [BindProperty] public List<Patrocinadores>? ListaPatrocinadores { get; set; }
        [BindProperty] public List<Administradores>? ListaAdministradores { get; set; }
        [BindProperty] public List<Reservas>? ListaReservas { get; set; }

        [BindProperty] public bool Borrando { get; set; }

        public EventosModel()
        {
            iEventosNegocio = new EventosNegocioP();
            iLugaresNegocio = new LugaresNegocioP();
            iClientesNegocio = new ClientesNegocioP();
            iHorariosNegocio = new HorariosNegocioP();
            iTipoEventosNegocio = new TipoEventosNegocioP();
            iInventariosNegocio = new InventariosNegocioP();
            iGruposNegocio = new GruposNegocioP();
            iPatrocinadoresNegocio = new PatrocinadoresNegocioP();
            iAdministradoresNegocio = new AdministradoresNegocioP();
            iReservasNegocio = new ReservasNegocioP();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
        }

        public void CargarRelaciones() {

            ListaLugares = iLugaresNegocio.Consultar();
            ListaClientes =  iClientesNegocio.Consultar();
            ListaHorarios = iHorariosNegocio.Consultar();
            ListaTipoEventos = iTipoEventosNegocio.Consultar();
            ListaInventarios = iInventariosNegocio.Consultar();
            ListaGrupos = iGruposNegocio.Consultar();
            ListaPatrocinadores = iPatrocinadoresNegocio.Consultar();
            ListaAdministradores = iAdministradoresNegocio.Consultar();
            ListaReservas = iReservasNegocio.Consultar();
        }


        public void OnPostBtRefrescar()
        {
            try
            {
                CargarRelaciones();
                if (iEventosNegocio == null) return;
                Lista = iEventosNegocio.Consultar();
                Evento = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtNuevo()
        {
            CargarRelaciones();
            Evento = new Eventos() { Fecha = DateTime.Now, Estado = true };
            Borrando = false;
        }

        public void OnPostBtBorrarVal(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Evento = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (Evento == null) return;
                Evento = iEventosNegocio!.Eliminar(Evento!);
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
                if (Evento == null) return;
                if (Evento.Id == 0)
                    Evento = iEventosNegocio!.Guardar(Evento!);
                else
                    Evento = iEventosNegocio!.Modificar(Evento!);

                if (Evento.Id == 0) return;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                CargarRelaciones(); // Evita perder los combos si hay error de validación
                ViewData["Mensaje"] = ex.Message;
            }
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Evento = Lista!.FirstOrDefault(x => x.Id == data);
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