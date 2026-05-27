using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using lib_eventos.nucleo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace pruebas_unitarias.conexiones
{
    [TestClass]
    public class ReservasUnitaria
    {
        private IConexion? iConexion;
        private Reservas? entidad;

        [TestMethod]
        public void Ejecutar()
        {
            Guardar();
            Consultar();
            Modificar();
            Borrar();
        }

        private void Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");
            var lista = iConexion.Reservas!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.entidad = new Reservas()
            {
                FechaReserva = new DateTime(2024, 6, 15),
                Ubicacion = "UT-" + DateTime.Now.ToString(),
                Observaciones = "Requiere montaje previo de 3 horas antes del evento",
                Estado = true,
            };
            this.iConexion.Reservas!.Add(this.entidad!);
            this.iConexion.SaveChanges();

            if (this.entidad.Id != 0)
                return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.entidad!.Estado = false;

            var entry = this.iConexion!.Entry<Reservas>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            if (entidad.Id != 0)
                return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.Reservas!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
        }
    }
}
