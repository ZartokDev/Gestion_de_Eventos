namespace lib_eventos.entidades
{
    public class Administradores
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }
        public String? Telefono { get; set; }
        public String? Correo { get; set; }
        public String? Contraseña { get; set; }

        public List<Eventos>? Eventos { get; set; }
        public List<Auditorias>? Auditorias { get; set; }
    }
}
