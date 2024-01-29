using OlhoVivo.Core.Domain.Validations;

namespace OlhoVivo.Core.Domain.Entities;

public class VehiclePosition
{
    #region Properties
    public long Id { get; set; }
    public Double Latitude { get; private set; }
    public Double Longitude { get; private set; }
    public long VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
    #endregion

    #region Constructor
    public VehiclePosition(Double latitude, Double longitude)
    {
        ValidateDomain(latitude, longitude);
        SetAtributes(latitude, longitude);
    }

    public VehiclePosition(long id, Double latitude, Double longitude)
    {
        DomainExceptionValidation.When(id < 0, "Id inválido!");
        
        ValidateDomain(latitude, longitude);
        SetAtributes(latitude, longitude);

        Id = id;
    }
    #endregion

    #region Methods

    public void Update(long id, Double latitude, Double longitude, long vehicleId)
    {
        DomainExceptionValidation.When(id < 0, "Id inválido!");
        DomainExceptionValidation.When(vehicleId < 0, "VehicleId inválido!");

        ValidateDomain(latitude, longitude);
        SetAtributes(latitude, longitude);

        Id = id;
        VehicleId = vehicleId;
    }

    private void SetAtributes(Double latitude, Double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    private void ValidateDomain(Double latitude, Double longitude)
    {
        DomainExceptionValidation.When(latitude > 90 || latitude < -90, "Latitude Inválida: O valor deve estar entre -90 até 90");
        DomainExceptionValidation.When(longitude > 180 || longitude < -180, "Longitude Inválida: O valor deve estar entre -180 até 180");
    }
    #endregion
}
