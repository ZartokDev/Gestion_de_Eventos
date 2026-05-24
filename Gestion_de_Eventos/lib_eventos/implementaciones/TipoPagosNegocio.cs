using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;

namespace lib_eventos.implementaciones
{
    public class TipoPagosNegocio : ITipoPagosNegocio
    {
        private IConexion? iConexion;

        public List<TipoPagos> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            var auditoria = new Auditorias()
            {
                TipoAccion = "Consultar Tipo de Pago",
                Descripcion = $"Se consulto un Tipo de Pago",
                Fecha = DateTime.Now,
                Administrador = null
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return this.iConexion.TipoPagos!.ToList();

        }
    }
}