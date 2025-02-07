using DesignPatterns.Creation;

internal class Program
{
    private static void Main(string[] args)
    {
        var singleton = new Singleton();

        Singleton.Instance.value = 5;
    }
}