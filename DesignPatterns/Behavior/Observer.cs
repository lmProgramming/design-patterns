using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavior;

public interface Observer
{
    void Update();
}

public abstract class Subject
{
    List<Observer> observers;

    public void Attach(Observer observer)
    {
        observers.Add(observer);
    }

    public void Detach(Observer observer)
    {
        observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in observers)
        {
            observer.Update();
        }
    }
}

public enum TextSeverity
{
    Warning,
    Information,
}

public class PriceModel : Subject
{
    public TextSeverity Severity { get; private set; }
    public string CurrencySymbol { get; private set; }
    public float Price { get; private set; }

    public PriceModel(TextSeverity _severity, string _currencySymbol, float _price)
    {
        Severity = _severity;
        CurrencySymbol = _currencySymbol;
        Price = _price;
    }
}

public class UiText : Observer
{
    private PriceModel priceModel;

    public string text { get; private set; }

    public UiText(PriceModel _priceModel)
    {
        priceModel = _priceModel;

        text = "";

        Update();
    }

    public void Update()
    {
        var endChar = priceModel.Severity switch
        {
            TextSeverity.Warning => '!',
            _ => '.',
        };
        text = $"Price is: {priceModel.Price}{priceModel.CurrencySymbol}{endChar}";
    }
}
