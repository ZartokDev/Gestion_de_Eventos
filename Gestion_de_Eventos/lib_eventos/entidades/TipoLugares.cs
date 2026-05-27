namespace lib_eventos.entidades
{
    public class TipoLugares
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }
        public int Capacidad { get; set; }
        public String? Descripcion { get; set; }
        public bool Estado { get; set; }

        public List<Lugares>? Lugares { get; set; }
    }
}