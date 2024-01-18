namespace TransportePublico.App.Commands.Paradas.Create
{
    public class NewParadaDto 
    {
    public string? Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public long LinhaId { get; set; }
    }
}