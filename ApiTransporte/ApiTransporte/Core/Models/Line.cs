using System.Text.Json.Serialization;

namespace ApiTransporte.Core.Models
{
    /// <summary>
    /// Classe das Linhas de ônibus
    /// </summary>
    public class Line
    {
        [JsonIgnore]
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
