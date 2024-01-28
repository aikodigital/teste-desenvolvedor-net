using OlhoVivo.Core.Domain.Validations;

namespace OlhoVivo.Core.Domain.Entities;

public class Stop
{
    #region Properties
    public long Id { get; private set; }
    public string Name { get; private set; }
    public Double Latitude { get; private set; }
    public Double Longitude { get; private set; }
    public long LineId { get; set; }
    public Line Line { get; set; }
    #endregion

    #region Constructor
    public Stop(string name, Double latitude, Double longitude)
    {
        ValidateDomain(name, latitude, longitude);
        SetAtributes(name, latitude, longitude);
    }

    public Stop(long id, string name, Double latitude, Double longitude)
    {
        DomainExceptionValidation.When(id < 0, "Id inválido!");
        
        ValidateDomain(name, latitude, longitude);
        SetAtributes(name, latitude, longitude);

        Id = id;
    }
    #endregion

    #region Methods

    public void Update(long id, string name, Double latitude, Double longitude, long lineId)
    {
        DomainExceptionValidation.When(id < 0, "Id inválido!");
        DomainExceptionValidation.When(lineId < 0, "LineId inválido!");

        ValidateDomain(name, latitude, longitude);
        SetAtributes(name, latitude, longitude);

        Id = id;
        LineId = lineId;
    }

    private void SetAtributes(string name, Double latitude, Double longitude)
    {
        Name = name;
        Latitude = latitude;
        Longitude = longitude;
    }

    private void ValidateDomain(string name, Double latitude, Double longitude)
    {
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "Informe o nome!");
        DomainExceptionValidation.When(name.Length < 3, "Nome inválido, é necessário ter no mínimo 3 caracteres!");

        DomainExceptionValidation.When(latitude > 90 || latitude < -90, "Latitude Inválida: O valor deve estar entre -90 até 90");
        DomainExceptionValidation.When(longitude > 180 || longitude < -180, "Longitude Inválida: O valor deve estar entre -180 até 180");
    }
    #endregion
}
