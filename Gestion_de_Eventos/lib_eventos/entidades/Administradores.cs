using System.ComponentModel.DataAnnotations.Schema;

namespace lib_eventos.entidades
{
    public class Administradores
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }
        public String? Telefono { get; set; }
        public String? Correo { get; set; }
        public String? Contraseña { get; set; }
        public int TipoAdministrador { get; set; }
        public bool Estado { get; set; }

        public List<Eventos>? Eventos { get; set; }
        public List<Auditorias>? Auditorias { get; set; }
        [ForeignKey("TipoAdministrador")] public TipoAdministradores? _TipoAdministradores { get; set; }
    }
}
