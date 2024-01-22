using System.Text.Json.Serialization;

namespace ApiTransporte.Core.Models
{
    /// <summary>
    /// Classe da Parada de ônibus
    /// </summary>
    public class BusStop
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
