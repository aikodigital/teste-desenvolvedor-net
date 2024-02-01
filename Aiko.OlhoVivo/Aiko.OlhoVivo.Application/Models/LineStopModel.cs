using Aiko.OlhoVivo.Infrastructure.Useful;

namespace Aiko.OlhoVivo.Application.Models;

/// <summary>
/// Class que contém as propriedades sobre a relação de linha x parada
/// </summary>
public class LineStopModel : BaseEntity
{
    /// <summary>
    /// Id da parada
    /// </summary>
    /// <example>5</example>
    public long StopId { get; set; }

    /// <summary>
    /// Id da Linha
    /// </summary>
    /// <example>8</example>
    public long LineId { get; set; }
}