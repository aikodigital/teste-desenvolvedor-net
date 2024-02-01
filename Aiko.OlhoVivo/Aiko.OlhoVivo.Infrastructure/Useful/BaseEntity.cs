using System.Text.Json.Serialization;

namespace Aiko.OlhoVivo.Infrastructure.Useful;

/// <summary>
/// Class que contém as propriedades base para outras class
/// </summary>
public class BaseEntity
{
    /// <summary>
    /// Identificador unido para registro ou consulta de entidade
    /// </summary>
    /// <example>2</example>
    public long Id { get; set; }

    /// <summary>
    /// Data relacionada ao cadastro da entidade
    /// </summary>
    /// <example>2023-01-25</example>
    [JsonIgnore]
    public DateTime DataCadastro { get; set; } = DateTime.Now;

    /// <summary>
    /// Data relacionada as alterações da entidade
    /// </summary>
    /// <example>2023-01-25</example>
    [JsonIgnore]
    public DateTime DataAlteracao { get; set; }

    /// <summary>
    /// Data relacionada a exclusão da entidade
    /// </summary>
    /// <example>2023-01-25</example>
    [JsonIgnore]
    public DateTime? DataExclusao { get; set; }

    /// <summary>
    /// Status que a entidade se enconta Ativo / Desativado
    /// </summary>
    /// <example>True</example>
    /// <example>False</example>
    [JsonIgnore]
    public bool Ativo { get; set; }
}