using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using OlhoVivo.Core.Domain.Entities;

namespace OlhoVivo.Core.Application.DTOs;

public class VehiclePositionDTO
{
    public long Id { get; set; }

    [Required(ErrorMessage = "Informe a Longitude!")]
    public Double Latitude { get; set; }

    [Required(ErrorMessage = "Informe a Longitude!")]
    public Double Longitude { get; set; }

    [DisplayName("Veículos")]
    public long VehicleId { get; set; }

    [JsonIgnore]
    public Vehicle? Vehicle { get; set; }
}
