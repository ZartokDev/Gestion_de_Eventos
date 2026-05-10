namespace lib_eventos.entidades
{
    public class Reservas
    {
        public int Id { get; set; }
        public DateTime? FechaReserva { get; set; }
        public String? Ubicacion { get; set; }
        public String? Observaciones { get; set; }
        public bool Estado { get; set; }

        public List<Eventos>? Eventos { get; set; }
    }
}
