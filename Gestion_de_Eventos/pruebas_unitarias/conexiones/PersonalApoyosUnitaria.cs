using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using lib_eventos.nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace pruebas_unitarias.conexiones
{
    [TestClass]
    public class PersonalApoyosUnitaria
    {
        private IConexion? iConexion;
        private PersonalApoyos? entidad;

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
            var lista = iConexion.PersonalApoyos!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.entidad = new PersonalApoyos()
            {
                Nombre = "UT-" + DateTime.Now.ToString(),
                Cantidad = 10,
                Horario = new DateTime(2024, 1, 1, 8, 0, 0),
                Estado = true,
            };
            this.iConexion.PersonalApoyos!.Add(this.entidad!);
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

            var entry = this.iConexion!.Entry<PersonalApoyos>(this.entidad!);
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

            this.iConexion.PersonalApoyos!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
        }
    }
}
