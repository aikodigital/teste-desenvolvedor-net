using System.Reflection;

namespace TransportePublico.Domain;

public interface IConfiguration
{
    public List<Assembly> Assemblies { get; set; }
    public List<Type> ComportamentosAbertos { get; set; }
}