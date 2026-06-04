using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pruebas_unitarias.comunicaciones
{
    [TestClass]
    public class ComunicacionesAuditoriaTest
    {
        private IComunicaciones? iComunicaciones;
        private Dictionary<string, object>? datosPeticion;

        private int _idAuditoriaRegistrada = 0;
        private string _urlBase = "https://localhost:7142/api/auditorias"; 

        [TestMethod]
        public async Task Ejecutar()
        {

            await Guardar();
            await Consultar();
            await Modificar();
            await Borrar();
        }

        private async Task Guardar()
        {
            this.iComunicaciones = new Comunicaciones();

            var nuevaAuditoria = new
            {
                Id = 0,
                TipoAccion = "COM-UT-Insertar-" + DateTime.Now.Ticks,
                Descripcion = "Auditoría desde Prueba de Comunicación",
                Fecha = DateTime.Now,
                Administrador = 1
            };

            this.datosPeticion = new Dictionary<string, object>
            {
                { "Url", _urlBase },
                { "Entidad", nuevaAuditoria }
            };

            var respuesta = await this.iComunicaciones.EjecutarPost(this.datosPeticion);

            if (respuesta != null && respuesta.ContainsKey("Valor"))
            {
                string jsonRespuesta = respuesta["Valor"].ToString()!;


                string jsonEstandar = jsonRespuesta.Replace("'", "\"");

                var resultadoObjeto = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonEstandar);

                if (resultadoObjeto != null && resultadoObjeto.ContainsKey("id"))
                {
                    _idAuditoriaRegistrada = Convert.ToInt32(resultadoObjeto["id"]);
                    if (_idAuditoriaRegistrada != 0) return;
                }
            }

            throw new Exception("❌ Error en Comunicaciones (Guardar): El API no retornó el ID válido del registro.");
        }

        private async Task Consultar()
        {
            this.iComunicaciones = new Comunicaciones();
            this.datosPeticion = new Dictionary<string, object>
            {
                { "Url", $"{_urlBase}/{_idAuditoriaRegistrada}" }
            };

            var respuesta = await this.iComunicaciones.Ejecutar(this.datosPeticion);

            if (respuesta != null && respuesta.ContainsKey("Valor") && !string.IsNullOrEmpty(respuesta["Valor"].ToString()))
                return;

            throw new Exception($"❌ Error en Comunicaciones (Consultar): No se pudo recuperar la auditoría con ID {_idAuditoriaRegistrada}.");
        }

        private async Task Modificar()
        {
            this.iComunicaciones = new Comunicaciones();

            var auditoriaModificada = new
            {
                Id = _idAuditoriaRegistrada,
                TipoAccion = "COM-UT-Modificado-" + DateTime.Now.Ticks,
                Descripcion = "Auditoría modificada desde prueba de comunicación",
                Fecha = DateTime.Now,
                Administrador = 1
            };

            this.datosPeticion = new Dictionary<string, object>
            {
                { "Url", _urlBase },
                { "Entidad", auditoriaModificada }
            };

            var respuesta = await this.iComunicaciones.EjecutarPatch(this.datosPeticion);

            if (respuesta != null && respuesta.ContainsKey("Valor"))
                return;

            throw new Exception("❌ Error en Comunicaciones (Modificar): Falló el envío de actualización.");
        }

        private async Task Borrar()
        {
            this.iComunicaciones = new Comunicaciones();
            this.datosPeticion = new Dictionary<string, object>
            {
                { "Url", $"{_urlBase}/{_idAuditoriaRegistrada}" }
            };

            var respuesta = await this.iComunicaciones.EjecutarDelete(this.datosPeticion);

            if (respuesta != null && respuesta.ContainsKey("Valor"))
                return;

            throw new Exception($"❌ Error en Comunicaciones (Borrar): El API rechazó la solicitud de eliminación.");
        }
    }
}