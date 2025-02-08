namespace DesignPatterns.Behavior;

public abstract class PasswordValidator
{
    private PasswordValidator? _next;

    public PasswordValidator SetNext(PasswordValidator nextValidator)
    {
        _next = nextValidator;
        return nextValidator;
    }

    public virtual bool Handle(string password)
    {
        return _next == null || _next.Handle(password);
    }
}

public class PasswordLengthValidator : PasswordValidator
{
    public override bool Handle(string password)
    {
        if (password.Length is >= 6 and <= 20) return base.Handle(password);
        
        Console.WriteLine("Password length must be between 6 and 20 characters.");
        return false;
    }
}

public class PasswordSpecialCharacterValidator : PasswordValidator
{
    public override bool Handle(string password)
    {
        if (!password.All(char.IsLetterOrDigit)) return base.Handle(password);
        
        Console.WriteLine("Password must contain at least one special character.");
        return false;
    }
}

public class PasswordLowerCaseValidator : PasswordValidator
{
    public override bool Handle(string password)
    {
        if (password.Any(char.IsLower)) return base.Handle(password);
        
        Console.WriteLine("Password must contain at least one lowercase letter.");
        return false;
    }
}

public class PasswordUpperCaseValidator : PasswordValidator
{
    public override bool Handle(string password)
    {
        if (password.Any(char.IsUpper)) return base.Handle(password);
        
        Console.WriteLine("Password must contain at least one uppercase letter.");
        return false;
    }
}

public class PasswordDigitValidator : PasswordValidator
{
    public override bool Handle(string password)
    {
        if (password.Any(char.IsDigit)) return base.Handle(password);
        
        Console.WriteLine("Password must contain at least one digit.");
        return false;
    }
}

public static class PasswordVerifier
{
    public static bool IsPasswordValid(string password)
    {
        var validatorChain = new PasswordLengthValidator();
        validatorChain
            .SetNext(new PasswordSpecialCharacterValidator())
            .SetNext(new PasswordLowerCaseValidator())
            .SetNext(new PasswordUpperCaseValidator())
            .SetNext(new PasswordDigitValidator());

        return validatorChain.Handle(password);
    }
}