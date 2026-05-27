using System.ComponentModel.DataAnnotations.Schema;

namespace lib_eventos.entidades
{
    public class GruposTrabajadores
    {
        public int Id { get; set; }
        public String? Descripcion { get; set; }
        public bool Estado { get; set; }


        public int Trabajador { get; set; }
        public int Grupo { get; set; }
        [ForeignKey("Trabajador")] public Trabajadores? _Trabajador { get; set; }
        [ForeignKey("Grupo")] public Grupos? _Grupo { get; set; }


    }
}
