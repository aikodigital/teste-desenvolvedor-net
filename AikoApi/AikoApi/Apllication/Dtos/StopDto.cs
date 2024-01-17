using System.ComponentModel.DataAnnotations;

namespace AikoApi.Apllication.Dtos;

    public class StopDto
    {
        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "A latitude é obrigatório")]
        public double Latitude { get; set; }
        [Required(ErrorMessage = "A longitute é obrigatório")]
        public double Longitude { get; set; }
        //[Required(ErrorMessage = "LineId é obrigatório")]
        //public long LineId { get; set; }
    }
