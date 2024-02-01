using Aiko.OlhoVivo.Infrastructure.Useful;

namespace Aiko.OlhoVivo.Infrastructure.Dto;

/// <summary>
/// Class que contém as propriedades relacionadas a linha
/// </summary>
public class Line : BaseEntity
{
    /// <summary>
    /// Nome da linha
    /// </summary>
    /// <example>São Geraldo</example>
    public string Name { get; set; }

    /// <summary>
    /// Lista de paradas relacionadas a linha
    /// </summary>
    public IEnumerable<Stop> Stop { get; set; } = new List<Stop>();

    /// <summary>
    /// Lista de vinculo linha x paradas relacionadas a linha
    /// </summary>
    public IEnumerable<LineStop> LineStop { get; set; } = new List<LineStop>();
}