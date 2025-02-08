using DesignPatterns;
using DesignPatterns.Structural;

namespace Tests;

public class StructuralTests
{
    [Fact]
    public void DecoratorTests()
    {
        var simple = new UserInfo();
        
        Assert.Equal("mikołaj kubś, pwr", simple.Operation());

        var decoratedA = new Capitalizer(simple);
        
        Assert.Equal("Mikołaj Kubś, Pwr", decoratedA.Operation());
        
        var decoratedB = new Introductor(decoratedA);
        
        Assert.Equal("Yep, that's me: Mikołaj Kubś, Pwr", decoratedB.Operation());
    }
}