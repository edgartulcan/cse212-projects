public class Person
{
    public readonly string Name;
    public int Turns { get; private set; }

    internal Person(string name, int turns)
    {
        Name = name;
        Turns = turns;
    }

    public bool HasInfiniteTurns => Turns <= 0;

    internal void UseTurn()
    {
        if (HasInfiniteTurns) return; // Do not modify infinite turns
        if (Turns > 0) Turns--;
    }

    public override string ToString()
    {
        return HasInfiniteTurns ? $"({Name}:Forever)" : $"({Name}:{Turns})";
    }
}
