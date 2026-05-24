using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;

namespace lib_eventos.implementaciones
{
    public class TipoTrabajadoresNegocio : ITipoTrabajadoresNegocio
    {
        private IConexion? iConexion;

        public List<TipoTrabajadores> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            var auditoria = new Auditorias()
            {
                TipoAccion = "Consultar Tipo de Trabajador",
                Descripcion = $"Se consulto un Tipo de Trabajador",
                Fecha = DateTime.Now,
                Administrador = null
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return this.iConexion.TipoTrabajadores!.ToList();

        }
    }
}