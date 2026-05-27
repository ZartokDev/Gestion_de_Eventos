namespace lib_eventos.entidades
{
    public class TipoAdministradores
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }
        public String? NivelAcceso { get; set; }
        public String? Descripcion { get; set; }
        public bool Estado { get; set; }

        public List<Administradores>? Administradores { get; set; }
    }
}
