using AikoApi.Models;

namespace AikoApi.Apllication.Dtos;

    public class LinesGetDto
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public LinesGetDto(Line model)
        {
            Id = model.Id;
            Name = model.Name;
        }
    }
