using lib_eventos.entidades;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace asp_presentaciones.Pages
{
    [AllowAnonymous]
    public class CalendarioModel : PageModel
    {
        private IEventosNegocioP iEventosNegocio;
        private ILugaresNegocioP iLugaresNegocio;
        private IHorariosNegocioP iHorariosNegocio; 

        public List<Lugares> ListaLugares { get; set; } = new List<Lugares>();

        public CalendarioModel()
        {
            iEventosNegocio = new EventosNegocioP();
            iLugaresNegocio = new LugaresNegocioP();
            iHorariosNegocio = new HorariosNegocioP();
        }

        public void OnGet()
        {
            ListaLugares = iLugaresNegocio.Consultar() ?? new List<Lugares>();
        }

        public JsonResult OnGetEventosJson()
        {
            var eventosBD = iEventosNegocio.Consultar() ?? new List<Eventos>();
            var lugaresBD = iLugaresNegocio.Consultar() ?? new List<Lugares>();
            var horariosBD = iHorariosNegocio.Consultar() ?? new List<Horarios>();

            // Validar si es Administrador
            bool esAdmin = User.Identity != null && User.Identity.IsAuthenticated && User.IsInRole("Administrador") || User.IsInRole("Moderador") || User.IsInRole("Trabajador");

            var eventosParaCalendario = eventosBD
                .Where(e => e.Estado == true)
                .Select(e => {
                    var lugar = lugaresBD.FirstOrDefault(l => l.Id == e.Lugar);

                    var horarioAsignado = horariosBD.FirstOrDefault(h => h.Id == e.Horario);
                    string fechaBase = e.Fecha.ToString("yyyy-MM-dd");

                    string horaBase = horarioAsignado != null ? horarioAsignado.HoraInicio.ToString() : "00:00:00";

                    string fechaHoraFullCalendar = $"{fechaBase}T{horaBase}";

                    string tituloFinal = esAdmin ? e.Nombre : "🔒 Ocupado";
                    string descripcionFinal = esAdmin ? e.Descripcion : "Reservado por un cliente.";
                    string lugarFinal = esAdmin ? (lugar != null ? lugar.Nombre : "Sede No Asignada") : "Kinetic Sede";
                    int personasFinal = esAdmin ? e.CantPersonas : 0;

                    string colorFondo = esAdmin ? "#2563eb" : "#334155";
                    string colorBorde = esAdmin ? "#3b82f6" : "#475569";

                    return new
                    {
                        id = e.Id,
                        title = tituloFinal,
                        start = fechaHoraFullCalendar,
                        description = descripcionFinal,
                        extendedProps = new
                        {
                            lugar = lugarFinal,
                            personas = personasFinal,
                            esAdmin = esAdmin
                        },
                        backgroundColor = colorFondo,
                        borderColor = colorBorde,
                        textColor = "#ffffff"
                    };
                }).ToList();

            return new JsonResult(eventosParaCalendario);
        }
    }
}