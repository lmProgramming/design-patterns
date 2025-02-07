using DesignPatterns.Creation;

namespace Tests;

public class CreationTests
{
    [Fact]
    public void Test1()
    {
        Singleton.Instance.value = 1;

        Assert.Equal(1, Singleton.Instance.value);
    }
}