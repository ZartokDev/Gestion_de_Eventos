using System.ComponentModel.DataAnnotations.Schema;

namespace lib_eventos.entidades
{
    public class Trabajadores
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }
        public String? Telefono { get; set; }
        public String? Correo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }

        public int TipoTrabajador { get; set; }
        public List<GruposTrabajadores>? GrupoTrabajadores { get; set; }
        [ForeignKey("TipoTrabajador")] public TipoTrabajadores? _TipoTrabajador { get; set; }


    }
}
