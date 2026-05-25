using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [ForeignKey("GrupoTrabajador")] [JsonIgnore]public GruposTrabajadores? _GrupoTrabajador { get; set; }
        [ForeignKey("Inventario")][JsonIgnore] public Inventarios? _Inventario { get; set; }
        [ForeignKey("Horario")][JsonIgnore] public Horarios? _Horario { get; set; }
        [ForeignKey("Administrador")][JsonIgnore] public Administradores? _Administrador { get; set; }
        [ForeignKey("TipoEvento")][JsonIgnore] public TipoEventos? _TipoEvento { get; set; }
        [ForeignKey("Patrocinador")][JsonIgnore] public Patrocinadores? _Patrocinador { get; set; }
        [ForeignKey("Lugar")][JsonIgnore] public Lugares? _Lugar { get; set; }
        [ForeignKey("Reserva")][JsonIgnore] public Reservas? _Reserva { get; set; }
        [ForeignKey("Cliente")][JsonIgnore] public Clientes? _Cliente { get; set; }

    }
}
