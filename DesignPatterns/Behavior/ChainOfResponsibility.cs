namespace DesignPatterns.Behavior;

public static class PasswordLengthChecker
{
    public static bool IsLengthValid(string password)
    {
        return password.Length is >= 6 and <= 20;
    }
}

public static class PasswordCharacterChecker
{
    public static bool HasSpecialCharacter(string password)
    {
        return !password.All(char.IsLetterOrDigit);
    }
    
    public static bool HasLowerCaseCharacter(string password)
    {
        return password.Any(char.IsLower);
    }
    
    public static bool HasUpperCaseCharacter(string password)
    {
        return password.Any(char.IsUpper);
    }
    
    public static bool HasDigitCharacter(string password)
    {
        return password.Any(char.IsDigit);
    }
}

public static class PasswordVerifier
{
    public static bool IsPasswordValid(string password)
    {
        if (!PasswordLengthChecker.IsLengthValid(password))
        {
            return false;
        }

        if (!PasswordCharacterChecker.HasSpecialCharacter(password))
        {
            return false;
        }

        if (!PasswordCharacterChecker.HasLowerCaseCharacter(password))
        {
            return false;
        }

        if (!PasswordCharacterChecker.HasUpperCaseCharacter(password))
        {
            return false;
        }

        if (!PasswordCharacterChecker.HasDigitCharacter(password))
        {
            return false;
        }
        
        return true;    
    }
}