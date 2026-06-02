using lib_eventos.entidades;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace asp_presentaciones.Pages
{
    public class CrearEventoModel : PageModel
    {
        private IEventosNegocioP iEventosNegocio;
        private ITipoEventosNegocioP iTipoEventosNegocio;
        private ILugaresNegocioP iLugaresNegocio;
        private IHorariosNegocioP iHorariosNegocio;

        // Propiedades vinculadas al formulario
        [BindProperty] public string NombreEvento { get; set; } = string.Empty;
        [BindProperty] public DateTime FechaEvento { get; set; } = DateTime.Now;
        [BindProperty] public string DescripcionEvento { get; set; } = string.Empty;
        [BindProperty] public int CantPersonas { get; set; }
        [BindProperty] public int IdTipoEvento { get; set; }
        [BindProperty] public int IdLugar { get; set; }
        [BindProperty] public int IdHorario { get; set; }

        // Aquí guardamos el ID del cliente que viene de la página anterior
        [BindProperty] public int IdCliente { get; set; }

        // Listas para llenar los selects sincronizados
        public List<TipoEventos>? ListaTipoEventos { get; set; }
        public List<Lugares>? ListaLugares { get; set; }
        public List<Horarios>? ListaHorarios { get; set; }

        public CrearEventoModel()
        {
            iEventosNegocio = new EventosNegocioP();
            iTipoEventosNegocio = new TipoEventosNegocioP();
            iLugaresNegocio = new LugaresNegocioP();
            iHorariosNegocio = new HorariosNegocioP();
        }

        // El parámetro 'id' de la URL entra automáticamente aquí
        public void OnGet(int id)
        {
            IdCliente = id;
            CargarRelaciones();
        }

        private void CargarRelaciones()
        {
            ListaTipoEventos = iTipoEventosNegocio.Consultar()?.Where(x => x.Estado).ToList(); ;
            ListaLugares = iLugaresNegocio.Consultar()?.Where(x => x.Estado).ToList(); ;
            ListaHorarios = iHorariosNegocio.Consultar()?.Where(x => x.Estado).ToList(); ;
        }

        public IActionResult OnPostGuardar()
        {
            try
            {
                if (string.IsNullOrEmpty(NombreEvento) || IdTipoEvento <= 0 || IdLugar <= 0 || IdHorario <= 0)
                {
                    ViewData["Mensaje"] = "Por favor, complete todos los campos obligatorios.";
                    CargarRelaciones();
                    return Page();
                }

                var todosEventos = iEventosNegocio.Consultar() ?? new List<Eventos>();

                bool salaOcupada = todosEventos.Any(e =>
                    e.Lugar == IdLugar &&
                    e.Fecha == FechaEvento &&
                    e.Estado == true
                );

                if (salaOcupada)
                {
                    ViewData["Mensaje"] = "🚨 Conflicto de Agenda: La sala o locación seleccionada ya se encuentra reservada para esa fecha y hora específica.";
                    CargarRelaciones();
                    return Page();
                }

                Eventos nuevoEvento = new Eventos()
                {
                    Nombre = NombreEvento,
                    Fecha = FechaEvento,
                    Descripcion = DescripcionEvento,
                    CantPersonas = CantPersonas,
                    Estado = true, // Restricción NOT NULL
                    TipoEvento = IdTipoEvento,
                    Lugar = IdLugar,
                    Horario = IdHorario,
                    Cliente = IdCliente, 

                    Grupo = 1,
                    Inventario = 1,
                    Administrador = 1,
                    Patrocinador = 1,
                    Reserva = 1
                };

                iEventosNegocio!.Guardar(nuevoEvento);

                var listaEventos = iEventosNegocio.Consultar();
                var eventoRecientementeCreado = listaEventos?
                    .Where(x => x.Cliente == nuevoEvento.Cliente)
                    .OrderByDescending(x => x.Id) 
                    .FirstOrDefault();

                if (eventoRecientementeCreado == null || eventoRecientementeCreado.Id == 0)
                {
                    ViewData["Mensaje"] = "El evento se guardó, pero no se pudo recuperar el ID de facturación.";
                    CargarRelaciones();
                    return Page();
                }

                return RedirectToPage("RegistrarPago", new { id = eventoRecientementeCreado.Id });
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = "Error al registrar el evento: " + ex.Message;
                CargarRelaciones();
                return Page();
            }
        }
    }
}