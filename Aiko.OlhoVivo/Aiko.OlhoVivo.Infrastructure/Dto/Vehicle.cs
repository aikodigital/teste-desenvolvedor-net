using Aiko.OlhoVivo.Infrastructure.Useful;

namespace Aiko.OlhoVivo.Infrastructure.Dto;

/// <summary>
/// Class que contém as propriedades relacionadas ao veiculo
/// </summary>
public class Vehicle : BaseEntity
{
    /// <summary>
    /// Nome do veiculo
    /// </summary>
    /// <example>Carro alegórico</example>
    public string Name { get; set; }

    /// <summary>
    /// Modelo do veiculo
    /// </summary>
    /// <example>Nave espacial</example>
    public string Modelo { get; set; }

    /// <summary>
    /// Entidade do veiculo
    /// </summary>
    public Line Line { get; set; }

    /// <summary>
    /// Linha do veiculo
    /// </summary>
    /// <example>8</example>
    public long LineId { get; set; }
}