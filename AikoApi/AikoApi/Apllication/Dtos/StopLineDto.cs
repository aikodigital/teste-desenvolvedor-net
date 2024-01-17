
using AikoApi.Models;

namespace AikoApi.Apllication.Dtos;

public class StopLineDto
{
	public String Name { get; set; }

    public StopLineDto(Line model)
    {
        Name = model.Name;
    }

}
