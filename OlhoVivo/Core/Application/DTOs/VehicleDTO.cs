using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using OlhoVivo.Core.Domain.Entities;

namespace OlhoVivo.Core.Application.DTOs;

public class VehicleDTO
{
    public long Id { get; set; }

    [Required(ErrorMessage = "Informe o Nome!")]
    [MinLength(5)]
    [MaxLength(100)]
    [DisplayName("Nome")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Informe o Modelo!")]
    [MinLength(5)]
    [MaxLength(100)]
    [DisplayName("Modelo")]
    public string Model { get; set; }

    [DisplayName("Linhas")]
    public long LineId { get; set; }
    
    [JsonIgnore]
    public Line? Line { get; set; }

    [JsonIgnore]
    public ICollection<Line>? Lines { get; set; }
}
