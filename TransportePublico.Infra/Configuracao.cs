using System.Reflection;
using TransportePublico.Domain;

namespace TransportePublico.Infra;

#nullable disable
public class Configuracao : IConfiguracao
{
    public List<Assembly> Assemblies { get; set; } = new();
}