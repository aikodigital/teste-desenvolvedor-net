namespace Core.ValueObjects
{
	public class Localizacao
	{
		public Localizacao(double latitude, double longitude)
		{
			Latitude = latitude;
			Longitude = longitude;
		}

		public double Latitude { get; private set; }
		public double Longitude { get; private set; }
	}
}
