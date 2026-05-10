namespace lib_eventos.entidades
{
    public class TipoPatrocinadores
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }
        public String? Descripcion { get; set; }
        public String? NivelAporte { get; set; }
        public String? Beneficios { get; set; }

        public List<Patrocinadores>? Patrocinadores { get; set; }
    }
}
