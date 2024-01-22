using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiTransporte.Core.Models
{
    /// <summary>
    /// Classe do Tipo de Transporte
    /// </summary>
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public long LineId { get; set; }
        public Line Line { get; set; }
    }
}
