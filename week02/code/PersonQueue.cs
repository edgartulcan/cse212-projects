
public class PersonQueue
{
    private readonly List<Person> _queue = new();
    public int Length => _queue.Count;

    public void Enqueue(Person person)
    {
        _queue.Add(person);             // FIX: añadir al final (FIFO)
    }

    public Person Dequeue()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("The queue is empty.");
        var person = _queue[0];
        _queue.RemoveAt(0);
        return person;
    }

    public bool IsEmpty() => Length == 0;

    public override string ToString() => $"[{string.Join(", ", _queue)}]";
}
