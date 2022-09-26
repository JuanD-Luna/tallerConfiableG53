using System.ComponentModel.DataAnnotations;

namespace tallerconfiable53.Models
{
    public class vehiculoModelo
    {
        public int idVehiculo { get; set; }
        public int idPropietario { get; set; }
        public int  identificacion{ get; set; }
        public string? placa { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? tipo { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? marca { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? modelo { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? capacidad { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? cilindraje { get; set; }
        public string? ciudadOrigen { get; set; }
        public string? descripcion { get; set; }
    }
}