using System.ComponentModel.DataAnnotations.Schema;

namespace lib_eventos.entidades
{
    public class Transportes
    {
        public int Id { get; set; }
        public String? Vehiculo { get; set; }
        public String? Placa { get; set; }
        public int Capacidad { get; set; }
        public bool Estado { get; set; }
        public int TipoTransporte { get; set; }

        public List<Grupos>? Grupos { get; set; }
        [ForeignKey("TipoTransporte")] public TipoTransportes? _TipoTransportes { get; set; }

    }
}
