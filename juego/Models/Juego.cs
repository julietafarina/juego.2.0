using System.ComponentModel.DataAnnotations;

namespace juego.Models
{
    public class Juego
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "El valor debe ser mayoy o igual a cero")]
        public int HorasJugadas { get; set; }
        public int Id_Desarrollador { get; set; }

        public Desarrollador? Desarrollador { get; set; }
    }
}
