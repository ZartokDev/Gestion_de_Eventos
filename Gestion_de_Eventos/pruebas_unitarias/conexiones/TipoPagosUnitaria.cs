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
    public class TipoPagosUnitaria
    {
        private IConexion? iConexion;
        private TipoPagos? entidad;

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
            var lista = iConexion.TipoPagos!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.entidad = new TipoPagos()
            {
                Nombre = "UT-" + DateTime.Now.ToString(),
                Descripcion = "Pago directo a cuenta bancaria de la empresa",
                Comision = 2,
                Estado = true,
            };
            this.iConexion.TipoPagos!.Add(this.entidad!);
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

            var entry = this.iConexion!.Entry<TipoPagos>(this.entidad!);
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

            this.iConexion.TipoPagos!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
        }
    }
}
