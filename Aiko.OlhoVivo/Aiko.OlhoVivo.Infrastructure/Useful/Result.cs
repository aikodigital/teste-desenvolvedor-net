using System.Text.Json.Serialization;

namespace Aiko.OlhoVivo.Infrastructure.Useful;

/// <summary>
/// Objeto de retorno padrão da API
/// </summary>
public class Result<T>
{
    public bool Sucesso { get; set; }
    public T Retorno { get; set; }
    public IEnumerable<string> Erros { get; set; } = Enumerable.Empty<string>();
    public IEnumerable<string> Sucessos { get; set; } = Enumerable.Empty<string>();
}