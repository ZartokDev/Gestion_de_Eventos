 namespace lib_eventos.entidades
{
    public class Clientes
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }
        public String? Telefono { get; set; }
        public String? Correo { get; set; }
        public bool Estado { get; set; }

        public List<Eventos>? Eventos { get; set; }
    }
}
