using System.ComponentModel.DataAnnotations.Schema;

namespace lib_eventos.entidades
{
    public class Patrocinadores
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }
        public String? Correo { get; set; }
        public String? Telefono { get; set; }
        public String? Direccion { get; set; }
        public bool Estado { get; set; }

        public int TipoPatrocinador { get; set; }
        public List<Eventos>? Eventos { get; set; }
        [ForeignKey("TipoPatrocinador")] public TipoPatrocinadores? _TipoPatrocinador { get; set; }
    }
}
