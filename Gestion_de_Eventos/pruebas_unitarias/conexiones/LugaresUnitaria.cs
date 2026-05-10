using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using lib_eventos.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias.conexiones
{
    [TestClass]
    public class LugaresUnitaria
    {
        private IConexion? iConexion;
        private Lugares? entidad;

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
            var lista = iConexion.Lugares!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            this.entidad = new Lugares()
            {
                Nombre = "UT-" + DateTime.Now.ToString(),
                Direccion = "Calle 100 #50-20, El Poblado",
                Capacidad = 500,
                Estado = true,
            };
            this.iConexion.Lugares!.Add(this.entidad!);
            this.iConexion.SaveChanges();

            if (this.entidad.Id != 0)
                return;
            throw new Exception("");
        }
        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            this.entidad!.Estado = false;

            var entry = this.iConexion!.Entry<Lugares>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            if (entidad.Id != 0)
                return;
            throw new Exception("");
        }

        private void Borrar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            this.iConexion.Lugares!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
        }
    }
}
