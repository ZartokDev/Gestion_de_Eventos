using System.ComponentModel.DataAnnotations.Schema;

namespace lib_eventos.entidades
{
    public class Inventarios
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }
        public bool EstadoProducto { get; set; }
        public String? Tipo { get; set; }
        public int Cantidad { get; set; }

        public int Proveedor { get; set; }
        public List<Eventos>? Eventos { get; set; }
        [ForeignKey("Proveedor")] public Proveedores? _Proveedor { get; set; }

    }
}
