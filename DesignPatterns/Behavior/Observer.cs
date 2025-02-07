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
    List<Observer> observers = new List<Observer>();

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
    Important,
    Information,
}

public class PriceModel : Subject
{
    public TextSeverity Severity { get; set; }
    public string CurrencySymbol { get; set; }
    public float Price { get; set; }

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
            TextSeverity.Important => '!',
            _ => '.',
        };
        text = $"Price is: {priceModel.Price}{priceModel.CurrencySymbol}{endChar}";
    }
}
