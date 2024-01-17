using AikoApi.Models;

namespace AikoApi.Apllication.Dtos;

    public class StopGetDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        //public long LineId { get; set; }
        //public long LineId { get; set; }
        public StopGetDto(Stop model)
        {
            Id = model.Id;
            Name = model.Name;
            Latitude = model.Latitude;
            Longitude = model.Longitude;
            //LineId = model.LineId;
        }
    }
