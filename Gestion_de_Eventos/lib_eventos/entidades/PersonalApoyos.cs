namespace lib_eventos.entidades
{
    public class PersonalApoyos
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }
        public int Cantidad { get; set; }
        public DateTime? Horario { get; set; }
        public bool Estado { get; set; }

        public List<Grupos>? Grupos { get; set; }
    }
}
