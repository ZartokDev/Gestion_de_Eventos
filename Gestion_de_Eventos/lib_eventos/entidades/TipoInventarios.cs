namespace lib_eventos.entidades
{
    public class TipoInventarios
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }
        public String? Categoria { get; set; }
        public String? Descripcion { get; set; }
        public bool Estado { get; set; }

        public List<Inventarios>? Inventarios { get; set; }
    }
}