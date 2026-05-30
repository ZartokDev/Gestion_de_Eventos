using lib_eventos.entidades;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace asp_presentaciones.Pages
{
    [Authorize]
    public class GruposModel : PageModel
    {
        private IGruposNegocioP iGruposNegocio;
        private IPersonalApoyosNegocioP iPersonalApoyosNegocio;
        private ITransportesNegocioP iTransportesNegocio;
        [BindProperty] public List<Grupos>? Lista { get; set; }
        [BindProperty] public Grupos? Grupo { get; set; }
        [BindProperty] public List<PersonalApoyos>? ListaPersonalApoyos { get; set; }
        [BindProperty] public List<Transportes>? ListaTransportes { get; set; }
        [BindProperty] public bool Borrando { get; set; }
 
        public GruposModel() 
        {
            iGruposNegocio = new GruposNegocioP();
            iPersonalApoyosNegocio = new PersonalApoyosNegocioP();
            iTransportesNegocio = new TransportesNegocioP();
        }


        public void OnGet()
        {
            OnPostBtRefrescar();
          

        }

        public void CargarRelaciones()
        {
            ListaPersonalApoyos = iPersonalApoyosNegocio.Consultar();
            ListaTransportes = iTransportesNegocio.Consultar();
        }   
        public void OnPostBtRefrescar()
        {
            try
            {
                CargarRelaciones();
                if (iGruposNegocio == null)
                    return;
                Lista = iGruposNegocio.Consultar();
                Grupo = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
           
        }

        public void OnPostBtNuevo()
        {
            CargarRelaciones();
            Borrando = false;
        }

        public void OnPostBtBorrarVal(int data)
        {

            try
            {
                OnPostBtRefrescar();
                Grupo = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (Grupo == null)
                    return;

                Grupo = iGruposNegocio!.Eliminar(Grupo!);
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
                if (Grupo == null) 
                    return;
                if (Grupo.Id == 0)
                    Grupo = iGruposNegocio!.Guardar(Grupo!);
                else
                {
                    Grupo = iGruposNegocio!.Modificar(Grupo!);
                }
                if (Grupo.Id == 0)
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
                Grupo = Lista!.FirstOrDefault(x => x.Id == data);
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