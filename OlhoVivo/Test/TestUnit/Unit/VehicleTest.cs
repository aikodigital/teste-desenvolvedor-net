using FluentAssertions;
using OlhoVivo.Core.Domain.Entities;
using OlhoVivo.Core.Domain.Validations;

namespace OlhoVivo.Test.Core.Domain.Unit;

public class VehicleTest
{
    #region Id
    [Fact(DisplayName = "Não deve criar veículo quando o id for negativo")]
    public void CreateVehicle_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Vehicle(-1, "Vehicle Name", "Model Name");

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Id inválido!");
    }
    #endregion

    #region Vehicle
    [Fact(DisplayName = "Criar veículo com o estado válido")]
    public void CreateVehicle_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Vehicle(1, "Vehicle Name", "Model Name");
        action.Should().NotThrow<DomainExceptionValidation>();
    }
    #endregion

    #region Name
    [Fact(DisplayName = "Não deve criar o veículo quando o nome for menor que 5 caracteres")]
    public void CreateVehicle_ShortNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Vehicle(1, "Vehi", "Model Name");

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Nome inválido, é necessário ter no mínimo 5 caracteres!");
    }

    [Fact(DisplayName = "Não deve criar o veículo quando o nome for vazio")]
    public void CreateVehicle_MissingNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Vehicle(1, "", "Model Name");

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Informe o nome!");
    }

    [Fact(DisplayName = "Não deve criar o veículo quando o nome for nulo")]
    public void CreateVehicle_WithNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Vehicle(1, null, "Model Name");

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Informe o nome!");
    }
    #endregion

    #region Model
    [Fact(DisplayName = "Não deve criar o veículo quando o modelo for menor que 3 caracteres")]
    public void CreateVehicle_ShortModelValue_DomainExceptionRequiredModel()
    {
        Action action = () => new Vehicle(1, "Vehicle Name", "Mo");

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Modelo inválido, é necessário ter no mínimo 3 caracteres!");
    }

    [Fact(DisplayName = "Não deve criar o veículo quando o modelo for vazio")]
    public void CreateVehicle_MissingModelValue_DomainExceptionRequiredModel()
    {
        Action action = () => new Vehicle(1, "Vehicle Name", "");

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Informe o modelo!");
    }

    [Fact(DisplayName = "Não deve criar o veículo quando o modelo for nulo")]
    public void CreateVehicle_WithModelValue_DomainExceptionInvalidModel()
    {
        Action action = () => new Vehicle(1, "Vehicle Name", null);

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Informe o modelo!");
    }
    #endregion
}
