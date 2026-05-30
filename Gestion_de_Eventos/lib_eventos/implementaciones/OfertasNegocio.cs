using lib_eventos.entidades;
using lib_eventos.interfaces;
using lib_eventos.nucleo;
using Microsoft.EntityFrameworkCore;

namespace lib_eventos.implementaciones
{
    public class OfertasNegocio : IOfertasNegocio
    {
        private IConexion? iConexion;

        public List<Ofertas> Consultar()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            var auditoria = new Auditorias()
            {
                TipoAccion = "Consultar Oferta",
                Descripcion = $"Se consulto una Oferta",
                Fecha = DateTime.Now,
                Administrador = null
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return this.iConexion.Ofertas!.ToList();

        }

        public Ofertas Guardar(Ofertas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.Ofertas!.Add(entidad!);
            this.iConexion.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Guardar Oferta",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se agrego una nueva Oferta con id: {entidad.Id} con descuento {entidad.Descuento}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();
            return entidad;
        }

        public Ofertas Modificar(Ofertas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardado ");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            this.iConexion.Ofertas.Attach(entidad);
            var entry = this.iConexion!.Entry<Ofertas>(entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Modificar Oferta",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se modifico una Oferta con id: {entidad.Id} con descuento {entidad.Descuento}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return entidad;
        }

        public Ofertas Eliminar(Ofertas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha eliminado");

            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuraciones.Obtener("StringConexion");

            var oferta = this.iConexion.Eventos!.FirstOrDefault(e => e.Id == entidad.Id);

            if (oferta == null)
                throw new Exception("El evento no existe");

            oferta.Estado = false;
            this.iConexion.Eventos!.Update(oferta);
            this.iConexion.SaveChanges();

            var auditoria = new Auditorias()
            {
                TipoAccion = "Eliminar Oferta",
                Fecha = DateTime.Now,
                Administrador = null,
                Descripcion = $"Se elimino una Oferta con id: {entidad.Id} con descuento {entidad.Descuento}"
            };

            this.iConexion.Auditorias!.Add(auditoria!);
            this.iConexion.SaveChanges();

            return entidad;
        }
    }
}