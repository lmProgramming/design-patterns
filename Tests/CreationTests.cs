using DesignPatterns.Creation;

namespace Tests;

public class CreationTests
{
    [Fact]
    public void SingletonTests()
    {
        Singleton.Instance.value = 1;

        Assert.Equal(1, Singleton.Instance.value);
    }

    [Fact]
    public void AbstractFactoryTests()
    {
        var factory = new ConcreteFactoryA();
        
        var a = factory.CreateA();
        var b = factory.CreateB();
        
        Assert.Equal("My text is: hello", a.Hello());
        Assert.Equal(100, b.MyNumber());
        
        var factory2 = new ConcreteFactoryB();
        
        a = factory2.CreateA();
        b = factory2.CreateB();
        
        Assert.Equal("My text is: HELLO", a.Hello());
        Assert.Equal(-10, b.MyNumber());
    }
}