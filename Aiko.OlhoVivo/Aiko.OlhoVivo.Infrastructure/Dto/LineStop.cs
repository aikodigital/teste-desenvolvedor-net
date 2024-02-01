using Aiko.OlhoVivo.Infrastructure.Useful;
using System.Text.Json.Serialization;

namespace Aiko.OlhoVivo.Infrastructure.Dto;

/// <summary>
/// Class que contém as propriedades sobre a relação de linha x parada
/// </summary>
public class LineStop : BaseEntity
{
    /// <summary>
    /// Id da parada
    /// </summary>
    /// <example>5</example>
    public long StopId { get; set; }
    public Stop Stop { get; set; }

    /// <summary>
    /// Id da parada
    /// </summary>
    /// <example>8</example>
    [JsonIgnore]
    public long LineId { get; set; }
    public Line Line { get; set; }
}