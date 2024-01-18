using System.Reflection;

namespace TransportePublico.Domain;

public interface IConfiguracao
{
    public List<Assembly> Assemblies { get; set; }
}