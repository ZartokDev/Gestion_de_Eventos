using lib_eventos.entidades;
using lib_eventos.implementaciones;
using lib_eventos.interfaces;
using lib_eventos.nucleo;
using Microsoft.EntityFrameworkCore;

namespace pruebas_unitarias.conexiones
{
    [TestClass]
    public class EventosUnitaria
    {
        private IConexion? iConexion;
        private Eventos? entidad;

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
            var lista = iConexion.Eventos!.ToList();
            if (lista.Count > 0)
                return;
            throw new Exception("");
        }

        private void Guardar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.entidad = new Eventos()
            {
                Nombre = "UT-" + DateTime.Now.ToString(),
                Fecha = new DateTime(2024, 9, 20),
                Descripcion = "Conferencia empresarial con speakers internacionales y zona de networking",
                CantPersonas = 300,
                Estado = true,
                GrupoTrabajador = 1,
                Inventario = 1,
                Horario = 1,
                Administrador = 1,
                TipoEvento = 1,
                Patrocinador = 1,
                Lugar = 1,
                Reserva = 1,
                Cliente = 1,
            };
            this.iConexion.Eventos!.Add(this.entidad!);
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

            var entry = this.iConexion!.Entry<Eventos>(this.entidad!);
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

            this.iConexion.Eventos!.Remove(this.entidad!);
            this.iConexion.SaveChanges();
        }
    }
}
