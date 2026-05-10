using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using lib_eventos.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias.conexiones
{
    [TestClass]
    public class PatrocinadoresUnitaria
    {
        private IConexion? iConexion;
        private Patrocinadores? entidad;

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
            var lista = iConexion.Patrocinadores!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            this.entidad = new Patrocinadores()
            {
                Nombre = "UT-" + DateTime.Now.ToString(),
                Correo = "patrocinios@bancolombia.com",
                Telefono = "6044444444",
                Direccion = "Carrera 48 #26-85, Medellín",
                TipoPatrocinador = 1,
            };
            this.iConexion.Patrocinadores!.Add(this.entidad!);
            this.iConexion.SaveChanges();

            if (this.entidad.Id != 0)
                return;
            throw new Exception("");
        }

        private void Modificar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            this.entidad!.Telefono = "000000000000000";

            var entry = this.iConexion!.Entry<Patrocinadores>(this.entidad!);
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

            this.iConexion.Patrocinadores!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
        }
    }
}
