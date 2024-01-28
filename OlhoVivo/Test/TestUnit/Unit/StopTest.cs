using FluentAssertions;
using OlhoVivo.Core.Domain.Entities;
using OlhoVivo.Core.Domain.Validations;

namespace OlhoVivo.Test.Core.Domain.Unit;

public class StopTest
{
    #region Id
    [Fact(DisplayName = "Não deve criar o ponto de parada quando o id for negativo")]
    public void CreateStop_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Stop(-1, "Ponto de Parada", -45.8675, 99.6487);

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Id inválido!");
    }
    #endregion

    #region Stop
    [Fact(DisplayName = "Criar ponto de parada com o estado válido")]
    public void CreateStop_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Stop(1, "Ponto de Parada", -45.8675, 99.6487);
        action.Should().NotThrow<DomainExceptionValidation>();
    }
    #endregion

    #region Name
    [Fact(DisplayName = "Não deve criar o ponto de parada quando o nome for menor que 3 caracteres")]
    public void CreateStop_ShortNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Stop(1, "Po", -45.8675, 99.6487);

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Nome inválido, é necessário ter no mínimo 3 caracteres!");
    }

    [Fact(DisplayName = "Não deve criar o ponto de parada quando o nome for vazio")]
    public void CreateStop_MissingNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Stop(1, "", -45.8675, 99.6487);

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Informe o nome!");
    }

    [Fact(DisplayName = "Não deve criar o ponto de parada quando o nome for nulo")]
    public void CreateStop_WithNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Stop(1, null, -45.8675, 99.6487);

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Informe o nome!");
    }
    #endregion

    #region Latitude
    [Fact(DisplayName = "Não deve criar o ponto de parada quando a latitude for menor que -90 graus")]
    public void CreateStop_WithLatitudeSmallerValue_DomainExceptionInvalidLatitude()
    {
        Action action = () => new Stop(1, "Ponto de Parada", -91.0000, 99.6487);

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Latitude Inválida: O valor deve estar entre -90 até 90");
    }

    [Fact(DisplayName = "Não deve criar o ponto de parada quando a latitude for maior que 90 graus")]
    public void CreateStop_WithLatitudeBiggerValue_DomainExceptionInvalidLatitude()
    {
        Action action = () => new Stop(1, "Ponto de Parada", 91.0000, 99.6487);

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Latitude Inválida: O valor deve estar entre -90 até 90");
    }
    #endregion

    #region Longitude
    [Fact(DisplayName = "Não deve criar o ponto de parada quando a Longitude for menor que -180 graus")]
    public void CreateStop_WithLongitudeSmallerValue_DomainExceptionInvalidLongitude()
    {
        Action action = () => new Stop(1, "Ponto de Parada", -45.8675, -181.0000);

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Longitude Inválida: O valor deve estar entre -180 até 180");
    }

    [Fact(DisplayName = "Não deve criar o ponto de parada quando a Longitude for maior que 180 graus")]
    public void CreateStop_WithLongitudeBiggerValue_DomainExceptionInvalidLongitude()
    {
        Action action = () => new Stop(1, "Ponto de Parada", -45.8675, 181.0000);

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Longitude Inválida: O valor deve estar entre -180 até 180");
    }
    #endregion
}
