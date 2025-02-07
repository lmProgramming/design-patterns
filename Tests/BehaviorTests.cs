using DesignPatterns.Behavior;

namespace Tests;

public class BehaviorTests
{
    [Fact]
    public void Test1()
    {
        var priceModel = new PriceModel(TextSeverity.Information, "$", 15.99f);

        var uiText = new UiText(priceModel);
        priceModel.Attach(uiText);

        Assert.Equal("Price is: 15,99$.", uiText.text);

        priceModel.Price = 9.99f;
        priceModel.Severity = TextSeverity.Important;

        priceModel.Notify();

        Assert.Equal("Price is: 9,99$!", uiText.text);

        priceModel.Detach(uiText);

        priceModel.Price = 5.99f;

        priceModel.Notify();

        Assert.Equal("Price is: 9,99$!", uiText.text);
    }
}