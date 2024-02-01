using Aiko.OlhoVivo.Infrastructure.Dto;
using Aiko.OlhoVivo.Infrastructure.Useful;
using System.Text.Json.Serialization;

namespace Aiko.OlhoVivo.Application.Models;

/// <summary>
/// Class que contém as propriedades relacionadas a linha
/// </summary>
public class LineModel : BaseEntity
{
    /// <summary>
    /// Nome da linha
    /// </summary>
    /// <example>São Geraldo</example>
    public string Name { get; set; }

    /// <summary>
    /// Paradas relacionadas a linha
    /// </summary>
    /// <example>Nome da parada - Ponto ET</example>
    /// <example>Latitude - 55.34</example>
    /// <example>Longitude - 98.56</example>
    public IEnumerable<StopModel> Stop { get; set; } = new List<StopModel>();


    public IEnumerable<LineStop> LineStop { get; set; } = new List<LineStop>();
}