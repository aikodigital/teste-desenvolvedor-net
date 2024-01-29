namespace OlhoVivo.Core.Domain.Validations;

public class DomainExceptionValidation : Exception
{
    public DomainExceptionValidation(string error) : base(error) { }

    public static void When(bool hasError, string error) 
    {
        if(hasError)
            throw new DomainExceptionValidation(error);
    }
}
