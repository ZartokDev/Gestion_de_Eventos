using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using lib_eventos.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias.conexiones
{
    [TestClass]
    public class TipoTrabajadoresUnitaria
    {
        private IConexion? iConexion;
        private TipoTrabajadores? entidad;

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
            var lista = iConexion.TipoTrabajadores!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            this.entidad = new TipoTrabajadores()
            {
                Nombre = "UT-" + DateTime.Now.ToString(),
                Salario = 3500000,
                Descripcion = "Encargado de coordinar todas las actividades del evento",
                Estado = true,
            };
            this.iConexion.TipoTrabajadores!.Add(this.entidad!);
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

            var entry = this.iConexion!.Entry<TipoTrabajadores>(this.entidad!);
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

            this.iConexion.TipoTrabajadores!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
        }
    }
}
