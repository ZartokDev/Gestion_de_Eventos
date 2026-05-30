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
    public class PersonalApoyosModel : PageModel
    {
        private IPersonalApoyosNegocioP iPersonalApoyosNegocio;
        [BindProperty] public List<PersonalApoyos>? Lista { get; set; }
        [BindProperty] public PersonalApoyos? PersonalApoyo { get; set; }
        [BindProperty] public bool Borrando { get; set; }
 
        public PersonalApoyosModel() 
        {
            iPersonalApoyosNegocio = new PersonalApoyosNegocioP();
        }

        public void OnGet()
        {
            OnPostBtRefrescar();
          

        }
        public void OnPostBtRefrescar()
        {
            try
            {
                if (iPersonalApoyosNegocio == null)
                    return;
                Lista = iPersonalApoyosNegocio.Consultar();
                PersonalApoyo = null;
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
           
        }

        public void OnPostBtNuevo()
        {
            Borrando = false;
        }

        public void OnPostBtBorrarVal(int data)
        {

            try
            {
                OnPostBtRefrescar();
                PersonalApoyo = Lista!.FirstOrDefault(x => x.Id == data);
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
                if (PersonalApoyo == null)
                    return;

                PersonalApoyo = iPersonalApoyosNegocio!.Eliminar(PersonalApoyo!);
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
                if (PersonalApoyo == null) 
                    return;
                if (PersonalApoyo.Id == 0)
                    PersonalApoyo = iPersonalApoyosNegocio!.Guardar(PersonalApoyo!);
                else
                {
                    PersonalApoyo = iPersonalApoyosNegocio!.Modificar(PersonalApoyo!);
                }
                if (PersonalApoyo.Id == 0)
                    return;
                OnPostBtRefrescar();
            }
            catch (Exception ex)
            {
                ViewData["Mensaje"] = ex.Message;
            }
            
        }

        public void OnPostBtModificar(int data)
        {
            try
            {
                OnPostBtRefrescar();
                PersonalApoyo = Lista!.FirstOrDefault(x => x.Id == data);
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