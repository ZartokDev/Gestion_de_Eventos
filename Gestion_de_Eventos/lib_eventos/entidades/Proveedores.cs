namespace lib_eventos.entidades
{
    public class Proveedores
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }
        public String? Telefono { get; set; }
        public String? Correo { get; set; }
        public String? TipoProducto { get; set; }
        public bool Estado { get; set; }

        public List<Inventarios>? Inventarios { get; set; }

    }
}
