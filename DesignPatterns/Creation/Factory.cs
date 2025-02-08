namespace DesignPatterns.Creation;

public interface IAnt
{
    string Act();
}

public class WorkerAnt : IAnt
{
    public string Act() => "Worker Ant: Collecting food.";
}

public class SoldierAnt : IAnt
{
    public string Act() => "Soldier Ant: Defending the colony.";
}

public class QueenAnt : IAnt
{
    public string Act() => "Queen Ant: Laying eggs.";
}

public enum AntType
{
    Worker,
    Soldier,
    Queen
}

public static class AntFactory
{
    public static IAnt CreateAnt(AntType type) => type switch
    {
        AntType.Worker => new WorkerAnt(),
        AntType.Soldier => new SoldierAnt(),
        AntType.Queen => new QueenAnt(),
        _ => throw new ArgumentException("Invalid ant type")
    };
}