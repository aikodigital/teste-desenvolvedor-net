using System.Runtime.Serialization;

namespace AikoApi.Models
{
	public class LineStop
	{
		public long Id { get; set; }
		public long LineId { get; set; }
		public long StopId { get; set; }
		[IgnoreDataMember]
		public Line Line { get; set; }
		[IgnoreDataMember]
		public Stop Stop { get; set; }

	}
}
