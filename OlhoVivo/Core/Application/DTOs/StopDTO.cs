using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using OlhoVivo.Core.Domain.Entities;

namespace OlhoVivo.Core.Application.DTOs;

public class StopDTO
{
    public long Id { get; set; }

    [Required(ErrorMessage = "Informe o Nome!")]
    [MinLength(3)]
    [MaxLength(100)]
    [DisplayName("Nome")] 
    public string Name { get; set; }

    [Required(ErrorMessage = "Informe a Latitude!")]
    public Double Latitude { get; set; }

    [Required(ErrorMessage = "Informe a Longitude!")]
    public Double Longitude { get; set; }

    [JsonIgnore]
    public Line? Line { get; set; }

    [DisplayName("Linhas")]
    public long LineId { get; set; }
}
