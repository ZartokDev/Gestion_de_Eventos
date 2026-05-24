using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;

namespace lib_eventos.implementaciones
{
    public class AuditoriasNegocio : IAuditoriasNegocio
    {
        private IConexion? iConexion;

        public List<Auditorias> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("string_conexion");

            var auditoria = new Auditorias()
            {
                TipoAccion = "Consultar Auditoria",
                Descripcion = $"Se consulto una Auditoria",
                Fecha = DateTime.Now,
                Administrador = null
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return this.iConexion.Auditorias!.ToList();
        }
    }
}