
namespace TransportePublico.App.Commands.Paradas.Update
{
    public class UpdateParadaDto 
    {
    public long Id { get; set; }
    public string? Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public long LinhaId { get; set; }
    }
}