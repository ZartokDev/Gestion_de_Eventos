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
    public class TipoLugaresUnitaria
    {
        private IConexion? iConexion;
        private TipoLugares? entidad;

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
            var lista = iConexion.TipoLugares!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.entidad = new TipoLugares()
            {
                Nombre = "UT-" + DateTime.Now.ToString(),
                Descripcion = "Pago directo a cuenta bancaria de la empresa",
                Estado = true,
            };
            this.iConexion.TipoLugares!.Add(this.entidad!);
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

            var entry = this.iConexion!.Entry<TipoLugares>(this.entidad!);
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

            this.iConexion.TipoLugares!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
        }
    }
}
