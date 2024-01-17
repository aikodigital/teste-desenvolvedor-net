using AikoApi.Apllication.Dtos;
using System.Runtime.Serialization;

namespace AikoApi.Models;

public class Line
{
	public long Id { get; set; }
	public string Name { get; set; }
	
	[IgnoreDataMember]
	public List<LineStop>? LineStops { get; set; } = new List<LineStop>();
}



