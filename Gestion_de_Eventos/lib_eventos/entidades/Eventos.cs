using System.ComponentModel.DataAnnotations.Schema;

namespace lib_eventos.entidades
{
    public class Eventos
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }
        public DateTime? Fecha { get; set; }
        public String? Descripcion { get; set; }
        public int CantPersonas { get; set; }
        public bool Estado { get; set; }


        public int GrupoTrabajador { get; set; }
        public int Inventario { get; set; }
        public int Horario { get; set; }
        public int Administrador { get; set; }
        public int TipoEvento { get; set; }
        public int Patrocinador { get; set; }
        public int Lugar { get; set; }
        public int Reserva { get; set; }
        public int Cliente { get; set; }

        public List<Facturas>? Facturas { get; set; }
        [ForeignKey("GrupoTrabajador")] public GruposTrabajadores? _GrupoTrabajador { get; set; }
        [ForeignKey("Inventario")] public Inventarios? _Inventario { get; set; }
        [ForeignKey("Horario")] public Horarios? _Horario { get; set; }
        [ForeignKey("Administrador")] public Administradores? _Administrador { get; set; }
        [ForeignKey("TipoEvento")] public TipoEventos? _TipoEvento { get; set; }
        [ForeignKey("Patrocinador")] public Patrocinadores? _Patrocinador { get; set; }
        [ForeignKey("Lugar")] public Lugares? _Lugar { get; set; }
        [ForeignKey("Reserva")] public Reservas? _Reserva { get; set; }
        [ForeignKey("Cliente")] public Clientes? _Cliente { get; set; }

    }
}
