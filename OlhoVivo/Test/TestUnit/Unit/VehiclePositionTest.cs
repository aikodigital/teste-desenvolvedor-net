using FluentAssertions;
using OlhoVivo.Core.Domain.Entities;
using OlhoVivo.Core.Domain.Validations;

namespace OlhoVivo.Test.Core.Domain.Unit;

public class VehiclePositionTest
{
    #region Id
    [Fact(DisplayName = "Não deve criar a posição do veículo quando o id for negativo")]
    public void CreateVehiclePosition_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new VehiclePosition(-1, -45.8675, 99.6487);

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Id inválido!");
    }
    #endregion

    #region Stop
    [Fact(DisplayName = "Criar posição do veículo com o estado válido")]
    public void CreateVehiclePosition_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new VehiclePosition(1, -45.8675, 99.6487);
        action.Should().NotThrow<DomainExceptionValidation>();
    }
    #endregion

    #region Latitude
    [Fact(DisplayName = "Não deve criar a posição do veículo quando a latitude for menor que -90 graus")]
    public void CreateVehiclePosition_WithLatitudeSmallerValue_DomainExceptionInvalidLatitude()
    {
        Action action = () => new VehiclePosition(1, -91.0000, 99.6487);

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Latitude Inválida: O valor deve estar entre -90 até 90");
    }

    [Fact(DisplayName = "Não deve criar a posição do veículo quando a latitude for maior que 90 graus")]
    public void CreateVehiclePosition_WithLatitudeBiggerValue_DomainExceptionInvalidLatitude()
    {
        Action action = () => new VehiclePosition(1, 91.0000, 99.6487);

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Latitude Inválida: O valor deve estar entre -90 até 90");
    }
    #endregion

    #region Longitude
    [Fact(DisplayName = "Não deve criar a posição do veículo quando a Longitude for menor que -180 graus")]
    public void CreateVehiclePosition_WithLongitudeSmallerValue_DomainExceptionInvalidLongitude()
    {
        Action action = () => new VehiclePosition(1, -45.8675, -181.0000);

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Longitude Inválida: O valor deve estar entre -180 até 180");
    }

    [Fact(DisplayName = "Não deve criar a posição do veículo quando a Longitude for maior que 180 graus")]
    public void CreateVehiclePosition_WithLongitudeBiggerValue_DomainExceptionInvalidLongitude()
    {
        Action action = () => new VehiclePosition(1, -45.8675, 181.0000);

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Longitude Inválida: O valor deve estar entre -180 até 180");
    }
    #endregion
}
