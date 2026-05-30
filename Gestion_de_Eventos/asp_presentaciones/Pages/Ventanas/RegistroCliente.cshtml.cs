using lib_eventos.entidades;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace asp_presentaciones.Pages
{
    public class RegistroClienteModel : PageModel
    {
        private IClientesNegocioP iClientesNegocio;
        [BindProperty] public List<Clientes>? Lista { get; set; }
        [BindProperty] public Clientes? Cliente { get; set; }
        [BindProperty] public string Nombre { get; set; } = string.Empty;
        [BindProperty] public string Documento { get; set; } = string.Empty;
        [BindProperty] public string Telefono { get; set; } = string.Empty;
        [BindProperty] public string Correo { get; set; } = string.Empty;


        public RegistroClienteModel()
        {
            iClientesNegocio = new ClientesNegocioP();
        }
        public void OnGet()
        {
            // Carga inicial de la página de registro
        }

        public async Task<IActionResult> OnPostBtRegistrarAsync()
        {
            try
            {
                // Validación básica de campos obligatorios en el servidor
                if (string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Documento) ||
                    string.IsNullOrEmpty(Telefono) || string.IsNullOrEmpty(Correo))
                {
                    ViewData["Mensaje"] = "Por favor, complete todos los campos obligatorios.";
                    return Page();
                }

                if (Cliente == null)
                {
                    ViewData["Mensaje"] = "Cliente no proporcionado.";
                    return Page();
                }

                if (Cliente.Id == 0)
                {
                    Cliente.Estado = true;
                    Cliente = iClientesNegocio!.Guardar(Cliente!);
                }
                else
                {
                    Cliente = iClientesNegocio!.Modificar(Cliente!);
                }
                if (Cliente.Id == 0)
                {
                    ViewData["Mensaje"] = "No se pudo guardar el cliente.";
                    return Page();
                }

                return RedirectToPage("../index");
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = "Error al procesar el registro: " + ex.Message;
                return Page();
            }
        }
    }
}