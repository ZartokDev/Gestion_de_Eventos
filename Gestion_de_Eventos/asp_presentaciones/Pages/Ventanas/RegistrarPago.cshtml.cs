using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace asp_presentaciones.Pages
{
    public class RegistrarPagoModel : PageModel
    {
        private IFacturasNegocioP iFacturasNegocio;
        private ITipoPagosNegocioP iTipoPagosNegocio;
        private IOfertasNegocioP iOfertasNegocio;
        private IEventosNegocioP iEventosNegocio;

        [BindProperty] public Facturas? Factura { get; set; }
        [BindProperty] public Eventos? EventoActual { get; set; }
        [BindProperty] public int IdEvento { get; set; }
        [BindProperty] public int IdTipoPago { get; set; }
        [BindProperty] public int? IdOferta { get; set; }

        public List<TipoPagos>? ListaTipoPagos { get; set; }
        public List<Ofertas>? ListaOfertas { get; set; }

        public RegistrarPagoModel()
        {
            iFacturasNegocio = new FacturasNegocioP();
            iTipoPagosNegocio = new TipoPagosNegocioP();
            iOfertasNegocio = new OfertasNegocioP();
            iEventosNegocio = new EventosNegocioP();
        }

        public IActionResult OnGet(int id)
        {
            IdEvento = id; // Aquí llega el ID del evento que YA se guardó en la base de datos
            return OnPostBtRefrescar();
        }

        public IActionResult OnPostBtRefrescar()
        {
            try
            {
                CargarRelaciones();

                var listaEventos = iEventosNegocio.Consultar();
                EventoActual = listaEventos?.FirstOrDefault(x => x.Id == IdEvento);

                if (EventoActual != null && Factura == null)
                {
                    // Lógica de negocio para calcular el total basado en la cantidad de personas
                    int totalCalculado = EventoActual.CantPersonas * 50000;

                    Factura = new Facturas
                    {
                        Id = 0, // Identificador de Factura (IDENTITY de SQL)
                        NumFactura = "FAC-" + DateTime.Now.ToString("yyyyMMdd") + "-" + EventoActual.Id,
                        FechaEmision = DateTime.Now,
                        Total = totalCalculado,
                        EstadoPago = false // false = Pendiente (BIT en SQL)
                    };
                }
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
            return Page();
        }

        private void CargarRelaciones()
        {
            ListaTipoPagos = iTipoPagosNegocio.Consultar()?.Where(x => x.Estado).ToList();
            ListaOfertas = iOfertasNegocio.Consultar()?.Where(x => x.Estado && x.FechaLimite >= DateTime.Now).ToList();
        }

        // Procesa el recálculo al cambiar la oferta en el combo
        public IActionResult OnPostBtAplicarOferta()
        {
            try
            {
                CargarRelaciones();

                var listaEventos = iEventosNegocio.Consultar();
                EventoActual = listaEventos?.FirstOrDefault(x => x.Id == IdEvento);

                if (EventoActual != null && Factura != null)
                {
                    int totalBase = EventoActual.CantPersonas * 50000;

                    if (IdOferta > 0 && ListaOfertas != null)
                    {
                        var ofertaSeleccionada = ListaOfertas.FirstOrDefault(x => x.Id == IdOferta);
                        if (ofertaSeleccionada != null)
                        {
                            int descuento = (totalBase * ofertaSeleccionada.Descuento) / 100;
                            Factura.Total = totalBase - descuento;

                            ViewData["InfoMensaje"] = $"¡Oferta aplicada! {ofertaSeleccionada.Descuento}% de descuento.";
                        }
                    }
                    else
                    {
                        Factura.Total = totalBase;
                    }

                    // 📝 CRÍTICO: Borra la caché del valor viejo para que la vista muestre el precio con descuento
                    ModelState.Remove("Factura.Total");
                }
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
            return Page();
        }

        // Guarda definitivamente la Factura en la base de datos
        public IActionResult OnPostBtGuardar()
        {
            try
            {
                if (Factura == null || IdTipoPago <= 0)
                {
                    ViewData["Mensaje"] = "Debe seleccionar un método de pago obligatorio.";
                    CargarRelaciones();
                    return Page();
                }

                // 1. Volvemos a consultar el evento para asegurar el precio base real en el servidor
                var listaEventos = iEventosNegocio.Consultar();
                EventoActual = listaEventos?.FirstOrDefault(x => x.Id == IdEvento);

                if (EventoActual != null)
                {
                    int totalBase = EventoActual.CantPersonas * 50000;

                    // 2. RECALCULAMOS EL DESCUENTO CRÍTICO: 
                    // Así nos aseguramos de que se guarde el precio rebajado en la base de datos
                    if (IdOferta > 0)
                    {
                        // Volvemos a cargar las relaciones si es necesario para buscar la oferta
                        ListaOfertas = iOfertasNegocio.Consultar()?.Where(x => x.Estado).ToList();
                        var ofertaSeleccionada = ListaOfertas?.FirstOrDefault(x => x.Id == IdOferta);

                        if (ofertaSeleccionada != null)
                        {
                            int descuento = (totalBase * ofertaSeleccionada.Descuento) / 100;
                            Factura.Total = totalBase - descuento;
                        }
                        else
                        {
                            Factura.Total = totalBase;
                        }
                    }
                    else
                    {
                        Factura.Total = totalBase;
                    }
                }

                // 3. Asignación de las llaves foráneas exactas para tu SQL Server
                Factura.Evento = IdEvento;       // FK a Eventos
                Factura.TipoPago = IdTipoPago;   // FK a TipoPagos
                Factura.Oferta = (int)IdOferta; // FK a Ofertas (o null si no hay)

                // EstadoPago es BIT NOT NULL en tu SQL, lo mandamos como true (Pagado)
                Factura.EstadoPago = true;

                // 4. Inserción final en la tabla Facturas con el precio corregido
                Factura = iFacturasNegocio.Guardar(Factura);

                if (Factura.Id == 0)
                {
                    ViewData["Mensaje"] = "No se pudo registrar la factura en la base de datos.";
                    CargarRelaciones();
                    return Page();
                }

                // Redirección al éxito
                return RedirectToPage("../Index");
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
                CargarRelaciones();
                return Page();
            }
        }
    }
}