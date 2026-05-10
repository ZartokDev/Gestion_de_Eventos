namespace lib_eventos.entidades
{
    public class TipoTrabajadores
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }
        public int Salario { get; set; }
        public String? Descripcion { get; set; }
        public bool Estado { get; set; }

        public List<Trabajadores>? Trabajadores { get; set; }
    }
}
