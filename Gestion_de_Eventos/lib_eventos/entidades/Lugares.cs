namespace lib_eventos.entidades
{
    public class Lugares
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }
        public String? Direccion { get; set; }
        public int Capacidad { get; set; }
        public bool Estado { get; set; }

        public List<Eventos>? Eventos { get; set; }
    }
}
