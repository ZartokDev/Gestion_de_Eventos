using lib_eventos.entidades;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace asp_presentaciones.Pages
{
    public class ReservaClienteModel : PageModel
    {
        private IClientesNegocioP iClientesNegocio;

        [BindProperty] public string DocumentoBusqueda { get; set; } = string.Empty;
        [BindProperty] public List<Clientes>? ListaClientes { get; set; }
        [BindProperty] public Clientes? ClienteEncontrado { get; set; }
        [BindProperty] public bool BusquedaRealizada { get; set; }

        public ReservaClienteModel()
        {
            iClientesNegocio = new ClientesNegocioP();
        }

        public void OnGet()
        {
            BusquedaRealizada = false;
            ClienteEncontrado = null;
        }

        // CAMBIO: Nombre del método simplificado para que coincida con asp-page-handler="Buscar"
        public IActionResult OnPostBuscar()
        {
            try
            {
                if (string.IsNullOrEmpty(DocumentoBusqueda))
                {
                    ViewData["Mensaje"] = "Por favor, ingrese un número de documento.";
                    BusquedaRealizada = false;
                    return Page();
                }

                ListaClientes = iClientesNegocio.Consultar();

                // Añadimos .Trim() para evitar que espacios invisibles rompan la búsqueda
                ClienteEncontrado = ListaClientes?.FirstOrDefault(x =>
                    x.Documento.Trim() == DocumentoBusqueda.Trim() && x.Estado);

                BusquedaRealizada = true;

                if (ClienteEncontrado == null)
                {
                    ViewData["Mensaje"] = "No se encontró ningún cliente activo con el documento ingresado.";
                }
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = "Error al consultar el cliente: " + ex.Message;
                BusquedaRealizada = false;
            }

            return Page();
        }

        // CAMBIO: Nombre simplificado para asp-page-handler="Continuar"
        public IActionResult OnPostContinuar(int idCliente)
        {
            if (idCliente <= 0)
            {
                ViewData["Mensaje"] = "Id de cliente no válido.";
                return Page();
            }
            return RedirectToPage("ReservarEvento", new { id = idCliente });
        }

        // CAMBIO: Nombre simplificado para asp-page-handler="Limpiar"
        public IActionResult OnPostLimpiar()
        {
            DocumentoBusqueda = string.Empty;
            ClienteEncontrado = null;
            BusquedaRealizada = false;
            return Page();
        }
    }
}