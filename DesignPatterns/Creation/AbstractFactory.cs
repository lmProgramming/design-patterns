namespace DesignPatterns.Creation;

public abstract class AbstractFactory
{
    public abstract A CreateA();

    public abstract B CreateB();
}

public abstract class A(string text)
{
    public string Hello()
    {
        return $"My text is: {text}";
    }
}

public abstract class B(int number)
{
    public int MyNumber()
    {
        return number;
    }
}

public class A1(string text) : A(text.ToLower())
{
    
}

public class A2(string text) : A(text.ToUpper())
{
    
}

public class B1(int number) : B(number * 10)
{
    
}

public class B2(int number) : B(-number)
{
    
}

public class ConcreteFactoryA : AbstractFactory
{
    public override A CreateA()
    {
        return new A1("Hello");
    }

    public override B CreateB()
    {
        return new B1(10);
    }
}

public class ConcreteFactoryB : AbstractFactory
{
    public override A CreateA()
    {
        return new A2("Hello");
    }

    public override B CreateB()
    {
        return new B2(10);
    }
}