using System.ComponentModel.DataAnnotations.Schema;

namespace lib_eventos.entidades
{
    public class Grupos
    {
        public int Id { get; set; }
        public String? Nombre { get; set; }
        public int Cantidad { get; set; }
        public int CantEventos { get; set; }
        public bool Estado { get; set; }


        public int PersonalApoyo { get; set; }
        public int Transporte { get; set; }
        public List<GruposTrabajadores>? GrupoTrabajadores { get; set; }
        public List<Eventos>? Eventos { get; set; }
        [ForeignKey("PersonalApoyo")] public PersonalApoyos? _PersonalApoyo { get; set; }
        [ForeignKey("Transporte")] public Transportes? _Transporte { get; set; }

    }
}
