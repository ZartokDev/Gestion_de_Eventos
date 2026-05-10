namespace lib_eventos.entidades
{
    public class TipoPagos
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }
        public String? Descripcion { get; set; }
        public int Comision { get; set; }
        public bool Estado { get; set; }

        public List<Facturas>? Facturas { get; set; }
    }
}
