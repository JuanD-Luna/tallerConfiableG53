using System.ComponentModel.DataAnnotations;

namespace tallerconfiable53.Models

{
    public class personaModelo
    {
        public int idPersona { get; set;}
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? identificacion { get; set;}
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? nombre { get; set;}
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? apellido { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? anoNacimiento { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? ciudad { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? email { get; set; }
    }
}
