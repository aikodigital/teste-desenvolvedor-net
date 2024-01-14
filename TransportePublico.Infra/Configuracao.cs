using System.Reflection;
using TransportePublico.Domain;

namespace TransportePublico.Infra;

#nullable disable
public class Configuracao : IConfiguration
{
    public List<Assembly> Assemblies { get; set; } = new();
    public List<Type> ComportamentosAbertos { get; set; } = new();
}