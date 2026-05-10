namespace lib_eventos.entidades
{
    public class Horarios
    {
        public int Id { get; set; }
        public String? HoraInicio { get; set; }
        public String? HoraFin { get; set; }
        public String? Turno { get; set; }
        public String? Descripcion { get; set; }
        public bool Estado { get; set; }

        public List<Eventos>? Eventos { get; set; }
    }
}
