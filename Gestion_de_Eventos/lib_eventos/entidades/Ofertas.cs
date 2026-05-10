namespace lib_eventos.entidades
{
    public class Ofertas
    {
        public int Id { get; set; }
        public DateTime? FechaLimite { get; set; }
        public int Descuento { get; set; }
        public String? Nombre { get; set; }
        public bool Estado { get; set; }

        public List<Facturas>? Facturas { get; set; }
    }
}
