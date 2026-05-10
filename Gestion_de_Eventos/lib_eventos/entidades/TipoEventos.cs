namespace lib_eventos.entidades
{
    public class TipoEventos
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }
        public String? DuracionEstimada { get; set; }
        public String? Descripcion { get; set; }
        public bool Estado { get; set; }

        public List<Eventos>? Eventos { get; set; }
    }
}
