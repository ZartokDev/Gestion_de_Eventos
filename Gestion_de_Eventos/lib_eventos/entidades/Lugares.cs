using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace lib_eventos.entidades
{
    public class Lugares
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }
        public String? Direccion { get; set; }
        public int Capacidad { get; set; }
        public bool Estado { get; set; }
        public int TipoLugar { get; set; }
        
        public List<Eventos>? Eventos { get; set; }

        [ForeignKey("TipoLugar")]public TipoLugares? _TipoLugares { get; set; }
    }
}
