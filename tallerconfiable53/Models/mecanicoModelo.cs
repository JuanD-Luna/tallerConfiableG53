using System.ComponentModel.DataAnnotations;
namespace tallerconfiable53.Models
{
    public class mecanicoModelo
    {
        public int idPersona { get; set; }
        public string? identificacion { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? nombre { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? apellido { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? anoNacimiento { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? telefono { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? direccion { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? nivelEducativo { get; set; }

    }
}
