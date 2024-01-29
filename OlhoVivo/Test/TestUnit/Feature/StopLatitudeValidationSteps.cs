using FluentAssertions;
using OlhoVivo.Core.Domain.Entities;
using OlhoVivo.Core.Domain.Validations;
using TechTalk.SpecFlow;

namespace OlhoVivo.Test.Core.Domain.Feature;

[Binding]
public class StopLatitudeValidationSteps
{
    #region Properties
    private double menorLatitude;
    private double maiorLatitude;
    private Action actionMenorLatitude;
    private Action actionMaiorLatitude;
    #endregion

    #region Tests

    #region Menor

    [Given("que estou inserindo uma latitude menor que -90")]
    public void GivenLatitudeSmallerValue()
    {
        menorLatitude = -91.0000;
    }

    [When("tento salvar a latitude com valor inferior ao permitido")]
    public void WhenLatitudeSmallerIsValidated()
    {
        actionMenorLatitude = () => new Stop(1, "Ponto de Parada", menorLatitude, 99.6487);
    }

    [Then("devo receber uma mensagem de erro indicando que a latitude inferior é inválida")]
    public void ThenLatitudeSmallerValidationShould()
    {
        actionMenorLatitude.Should()
                           .Throw<DomainExceptionValidation>()
                           .WithMessage("Latitude Inválida: O valor deve estar entre -90 até 90");
    }
    #endregion

    #region Maior

    [Given("que estou inserindo uma latitude maior que 90")]
    public void GivenLongitudeBiggerValue()
    {
        maiorLatitude = 91.0000;
    }

    [When("tento salvar a latitude com valor superior ao permitido")]
    public void WhenLongitudeBiggerIsValidated()
    {
        actionMaiorLatitude = () => new Stop(1, "Ponto de Parada", maiorLatitude, 99.6487);
    }

    [Then("devo receber uma mensagem de erro indicando que a latitude superior é inválida")]
    public void ThenLongitudeBiggerValidationShould()
    {
        actionMaiorLatitude.Should()
                           .Throw<DomainExceptionValidation>()
                           .WithMessage("Latitude Inválida: O valor deve estar entre -90 até 90");
    }
    #endregion
    
    #endregion
}
