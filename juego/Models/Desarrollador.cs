using System.ComponentModel.DataAnnotations;

namespace juego.Models
{
    public class Desarrollador
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}
