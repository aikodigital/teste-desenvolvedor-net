using Aiko.OlhoVivo.Infrastructure.Useful;

namespace Aiko.OlhoVivo.Application.Models;

/// <summary>
/// Class que contém as propriedades relacionadas a posição do veiculo
/// </summary>
public class VehiclePositionModel : BaseEntity
{
    /// <summary>
    /// Posição geográfica latitudinal
    /// </summary>
    /// <example>35º N (35 graus ao norte)</example>
    public string Latitude { get; set; }

    /// <summary>
    /// Posição geográfica longitudinal
    /// </summary>
    /// <example>65º O (65 graus ao oeste)</example>
    public string Longitude { get; set; }

    /// <summary>
    /// Id do veiculo
    /// </summary>
    /// <example>34</example>
    public long VehicleId { get; set; }
}