using DesignPatterns.Behavior;

namespace Tests;

public class BehaviorTests
{
    [Fact]
    public void Test1()
    {
        var priceModel = new PriceModel(TextSeverity.Warning, "$", 15.5f);

        var uiText = new UiText(priceModel);

        Assert.Equal("Price is: 15,5$!", uiText.text);
    }
}