using AikoApi.Apllication.Dtos;
using System.Runtime.Serialization;

namespace AikoApi.Models;

public class Stop
{
	public long Id { get; set; }
	public string Name { get; set; }
	public double Latitude { get; set; }
	public double Longitude { get; set; }
	[IgnoreDataMember]
	public List<LineStop>? LineStops { get; set; } = new List<LineStop>();

}
