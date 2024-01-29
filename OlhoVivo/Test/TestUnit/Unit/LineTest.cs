using FluentAssertions;
using OlhoVivo.Core.Domain.Entities;
using OlhoVivo.Core.Domain.Validations;

namespace OlhoVivo.Test.Core.Domain.Unit;

public class LineTest
{
    #region Id
    [Fact(DisplayName = "Não deve criar linha quando o id for negativo")]
    public void CreateLine_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Line(-1, "Line Name");

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Id inválido!");
    }
    #endregion

    #region Line

    [Fact(DisplayName = "Criar linha com o estado válido")]
    public void CreateLine_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Line(1, "Line Name");
        action.Should().NotThrow<DomainExceptionValidation>();
    }
    #endregion

    #region Name
    [Fact(DisplayName = "Não deve criar linha quando o nome for menor que 5 caracteres")]
    public void CreateLine_ShortNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Line(1, "Line");

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Nome inválido, é necessário ter no mínimo 5 caracteres!");
    }

    [Fact(DisplayName = "Não deve criar linha quando o nome for vazio")]
    public void CreateLine_MissingNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Line(1, "");

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Informe o nome!");
    }

    [Fact(DisplayName = "Não deve criar linha quando o nome for nulo")]
    public void CreateLine_WithNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Line(1, null);

        action.Should()
              .Throw<DomainExceptionValidation>()
              .WithMessage("Informe o nome!");
    }
    #endregion
}
