using OlhoVivo.Core.Domain.Validations;

namespace OlhoVivo.Core.Domain.Entities;

public class Vehicle
{
    #region Properties
    public long Id { get; private set; }
    public string Name { get; private set; }
    public string Model { get; private set; }
    public long LineId { get; set; }
    public Line Line { get; set; }
    public VehiclePosition VehiclePosition { get; set; }
    #endregion

    #region Constructor
    public Vehicle(string name, string model)
    {
        ValidateDomain(name, model);
        SetAtributes(name, model);
    }

    public Vehicle(long id, string name, string model)
    {
        DomainExceptionValidation.When(id < 0, "Id inválido!");

        ValidateDomain(name, model);
        SetAtributes(name, model);

        Id = id;
    }
    #endregion
    
    #region Methods

    public void Update(long id, string name, string model, long lineId)
    {
        DomainExceptionValidation.When(id < 0, "Id inválido!");
        DomainExceptionValidation.When(lineId < 0, "LineId inválido!");
        
        ValidateDomain(name, model);
        SetAtributes(name, model);

        Id = id;
        LineId = lineId;
    }

    private void SetAtributes(string name, string model)
    {
        Name = name;
        Model = model;
    }

    private void ValidateDomain(string name, string model)
    {
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "Informe o nome!");
        DomainExceptionValidation.When(name.Length < 5, "Nome inválido, é necessário ter no mínimo 5 caracteres!");

        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(model), "Informe o modelo!");
        DomainExceptionValidation.When(model.Length < 3, "Modelo inválido, é necessário ter no mínimo 3 caracteres!");
    }
    #endregion
}
