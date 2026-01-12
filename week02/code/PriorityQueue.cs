using System;
using System.Collections.Generic;

public class PriorityQueue
{
    private readonly List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.  The
    /// node is always added to the back of the queue regardless of 
    /// the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }


    public string Dequeue()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        // Buscar el índice del elemento con mayor prioridad
        int highPriorityIndex = 0;
        for (int index = 1; index < _queue.Count; index++) // FIX: incluir el último
        {
            // FIX: usar '>' para mantener FIFO en empates (no mover si son iguales)
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
                highPriorityIndex = index;
        }

        // FIX: eliminar el elemento antes de devolver su valor
        string value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex);
        return value;
    }


    // DO NOT MODIFY THE CODE IN THIS METHOD
    // The graders rely on this method to check if you fixed all the bugs, so changes to it will cause you to lose points.
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    // DO NOT MODIFY THE CODE IN THIS METHOD
    // The graders rely on this method to check if you fixed all the bugs, so changes to it will cause you to lose points.
    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}