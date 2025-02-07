using DesignPatterns;

internal class Program
{
    private static void Main(string[] args)
    {
        var singleton = new Singleton();

        Singleton.Instance.value = 5;
    }
}