using System.ComponentModel.DataAnnotations;

namespace AikoApi.Apllication.Dtos;

    public class VehicleDto
    {
        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O Modelo é obrigatório")]
        public string Model { get; set; }
        [Required(ErrorMessage = "LineId é obrigatório")]
        public long LineId { get; set; }
    }
