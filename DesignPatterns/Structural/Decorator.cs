using System.Globalization;

namespace DesignPatterns.Structural;

public abstract class Component
{
    public abstract string Operation();
}

public class UserInfo : Component
{
    public override string Operation()
    {
        return "mikołaj kubś, pwr";
    }
}

public abstract class Decorator(Component component) : Component
{
    public Component? Component { get; set; } = component;

    public override string Operation()
    {
        if (Component is not null)
        {
            return Component.Operation();
        }
        
        return string.Empty;
    }
}

public class Capitalizer(Component component) : Decorator(component)
{
    private readonly TextInfo _textInfo = new CultureInfo("en-US", false).TextInfo;
    private readonly Component _component = component;

    public override string Operation()
    {
        return _textInfo.ToTitleCase(_component.Operation());
    }
}

public class Introductor(Component component) : Decorator(component)
{
    public override string Operation()
    {
        return $"Yep, that's me: {base.Operation()}";
    }
}