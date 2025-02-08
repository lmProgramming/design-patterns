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

    [Fact]
    public void FactoryTests()
    {
        var ant1 = AntFactory.CreateAnt(AntType.Worker);
        var ant2 = AntFactory.CreateAnt(AntType.Soldier);
        var ant3 = AntFactory.CreateAnt(AntType.Queen);
        
        Assert.Equal("Worker Ant: Collecting food.", ant1.Act());
        
        Assert.Equal("Soldier Ant: Defending the colony.", ant2.Act());
        
        Assert.Equal("Queen Ant: Laying eggs.", ant3.Act());
    }
}