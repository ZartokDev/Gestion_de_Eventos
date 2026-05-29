using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using lib_eventos.entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace asp_presentaciones.Pages
{
    public class LoginModel : PageModel
    {
        private IAdministradoresNegocioP iAdministradoresNegocio;

        [BindProperty] public string Correo { get; set; } = string.Empty;
        [BindProperty] public string Contraseña { get; set; } = string.Empty; // Mantenemos la Ñ

        public LoginModel()
        {
            iAdministradoresNegocio = new AdministradoresNegocioP(); // O AdministradoresNegocioP() según tu clase
        }

        public void OnGet()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
        }

        public async Task<IActionResult> OnPostBtIngresarAsync()
        {
            try
            {
                if (iAdministradoresNegocio == null)
                {
                    ViewData["Mensaje"] = "Error interno: El servicio de negocio no está disponible.";
                    return Page();
                }

                var listaAdmins = iAdministradoresNegocio.Consultar();

                // Buscamos comparando estrictamente con 'Contraseña'
                var adminLogueado = listaAdmins?.FirstOrDefault(x =>
                    x.Correo.Trim().ToLower() == Correo.Trim().ToLower() &&
                    x.Contraseña == Contraseña);

                if (adminLogueado != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, adminLogueado.Id.ToString()),
                        new Claim(ClaimTypes.Name, adminLogueado.Nombre),
                        new Claim(ClaimTypes.Email, adminLogueado.Correo),
                        new Claim(ClaimTypes.Role, "Administrador")
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties
                    );

                    return RedirectToPage("/Index"); // Redirige a la raíz de Pages
                }
                else
                {
                    ViewData["Mensaje"] = "Correo electrónico o contraseña incorrectos.";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = "Error en el servidor: " + ex.Message;
                return Page();
            }
        }

        public async Task<IActionResult> OnPostBtCerrarSesionAsync()
        {
            try
            {
                // 1. Borra la cookie de autenticación y limpia el contexto de seguridad
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = "Error al cerrar sesión: " + ex.Message;
            }

            // 2. Redirige inmediatamente a la pantalla de Login
            return RedirectToPage("/Ventanas/Login");
        }
    }
}