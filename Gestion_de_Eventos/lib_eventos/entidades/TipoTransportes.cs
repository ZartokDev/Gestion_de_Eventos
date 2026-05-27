namespace lib_eventos.entidades
{
    public class TipoTransportes
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }
        public int Capacidad { get; set; }
        public String? Descripcion { get; set; }
        public bool Estado { get; set; }

        public List<Transportes>? Transportes{ get; set; }
    }
}
