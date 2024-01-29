using OlhoVivo.Core.Domain.Validations;

namespace OlhoVivo.Core.Domain.Entities;

public class Line
{
    #region Properties
    public long Id { get; private set; }
    public string Name { get; private set; }
    public ICollection<Vehicle>? Vehicles { get; set; }
    public ICollection<Stop>? Stops { get; set; }
    #endregion

    #region Constructor
    public Line(string name)
    {
        ValidateDomain(name);
        Name = name;
    }

    public Line(long id, string name)
    {
        DomainExceptionValidation.When(id < 0, "Id inválido!");

        ValidateDomain(name);

        Id = id;
        Name = name;
    }
    #endregion

    #region Methods

    public void Update(long id, string name)
    {
        DomainExceptionValidation.When(id < 0, "Id inválido!");

        ValidateDomain(name);

        Id = id;
        Name = name;
    }

    private void ValidateDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "Informe o nome!");
        DomainExceptionValidation.When(name.Length < 5, "Nome inválido, é necessário ter no mínimo 5 caracteres!");
    }
    #endregion
}
