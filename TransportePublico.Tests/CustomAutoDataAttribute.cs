namespace TransportePublico.Tests.Testes;

public class CustomAutoDataAttribute : AutoDataAttribute
{
    public CustomAutoDataAttribute()
        : base(() =>
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            fixture
                .Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            return fixture;
        })
    {
    }
}