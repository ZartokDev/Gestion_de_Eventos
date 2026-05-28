using System.ComponentModel.DataAnnotations.Schema;

namespace lib_eventos.entidades
{
    public class Facturas
    {
        public int Id { get; set; }
        public String? NumFactura { get; set; }
        public DateTime FechaEmision { get; set; }
        public int Total { get; set; }
        public bool EstadoPago { get; set; }

        public int TipoPago { get; set; }
        public int Oferta { get; set; }
        public int Evento { get; set; }

        [ForeignKey("TipoPago")] public TipoPagos? _TipoPago { get; set; }
        [ForeignKey("Oferta")] public Ofertas? _Oferta { get; set; }
        [ForeignKey("Evento")] public Eventos? _Evento { get; set; }

    }
}
