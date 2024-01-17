using AikoApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AikoApi.Apllication.Dtos
{
    public class LineDto
    {
        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Name { get; set; }
    }
}
