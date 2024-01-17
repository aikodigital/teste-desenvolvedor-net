using System.ComponentModel.DataAnnotations;

namespace AikoApi.Apllication.Dtos;

    public class VehiclePositionDto
    {
        [Required(ErrorMessage = "Latitude obrigatório")]
        public double Latitude { get; set; }
        [Required(ErrorMessage = "Longitude obrigatório")]
        public double Longitude { get; set; }
        [Required(ErrorMessage = "VehicleId é obrigatório")]
        public long VehicleId { get; set; }
    }
