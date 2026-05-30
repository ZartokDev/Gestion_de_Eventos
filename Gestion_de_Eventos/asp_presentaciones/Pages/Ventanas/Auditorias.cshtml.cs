using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace asp_presentaciones.Pages
{
    [Authorize]
    public class AuditoriasModel : PageModel
    {
        private IAuditoriasNegocioP iAuditoriasNegocio;

        private IAdministradoresNegocioP iAdministradoresNegocio;
        [BindProperty] public List<Auditorias>? Lista { get; set; }
        [BindProperty] public Auditorias? Auditoria { get; set; }
        [BindProperty] public List<Administradores>? ListaAdministradores { get; set; }
        [BindProperty] public bool Borrando { get; set; }
 
        public AuditoriasModel() 
        {
            iAuditoriasNegocio = new AuditoriasNegocioP();
            iAdministradoresNegocio = new AdministradoresNegocioP();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
          

        }

        public void CargarRelaciones()
        {
            ListaAdministradores = iAdministradoresNegocio.Consultar();
        }
        public void OnPostBtRefrescar()
        {
            try
            {
                CargarRelaciones();
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

        public void OnPostBtNuevo()
        {
            CargarRelaciones();
            Auditoria = new Auditorias() { Fecha = DateTime.Now};
            Borrando = false;
        }

        public void OnPostBtBorrarVal(int data)
        {

            try
            {
                OnPostBtRefrescar();
                Auditoria = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (Auditoria == null)
                    return;

                Auditoria = iAuditoriasNegocio!.Eliminar(Auditoria!);
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
                if (Auditoria == null)
                    return;
                if (Auditoria.Id == 0)
                    Auditoria = iAuditoriasNegocio!.Guardar(Auditoria!);
                else
                {
                    Auditoria = iAuditoriasNegocio!.Modificar(Auditoria!);
                }
                if (Auditoria.Id == 0)
                    return;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                CargarRelaciones();
                ViewData["Mensaje"] = ex.Message;
            }

        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                Auditoria = Lista!.FirstOrDefault(x => x.Id == data);
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