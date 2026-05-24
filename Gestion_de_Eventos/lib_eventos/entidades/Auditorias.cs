using System.ComponentModel.DataAnnotations.Schema;

namespace lib_eventos.entidades
{
    public class Auditorias
    {
        public int Id { get; set; }
        public String? TipoAccion { get; set; }
        public String? Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Administrador { get; set; }

        [ForeignKey("Administrador")] public Administradores? _Administrador { get; set; }

    }
}
