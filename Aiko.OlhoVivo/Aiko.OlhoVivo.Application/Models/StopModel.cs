using Aiko.OlhoVivo.Infrastructure.Useful;

namespace Aiko.OlhoVivo.Application.Models;

/// <summary>
/// Class que contém as propriedades relacionadas a parada
/// </summary>
public class StopModel : BaseEntity
{
    /// <summary>
    /// Nome da parada
    /// </summary>
    /// <example>Ponto do ET</example>
    public string Name { get; set; }

    /// <summary>
    /// Posição geográfica latitudinal
    /// </summary>
    /// <example>35º N (35 graus ao norte)</example>
    public double? Latitude { get; set; }

    /// <summary>
    /// Posição geográfica longitudinal
    /// </summary>
    /// <example>65º O (65 graus ao oeste)</example>
    public double? Longitude { get; set; }
}