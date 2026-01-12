/// <summary>
/// This queue is circular.  When people are added via AddPerson, then they are added to the 
/// back of the queue (per FIFO rules).  When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue.  Thus,
/// each person stays in the queue and is given turns.  When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given.  If the turns is 0 or
/// less than they will stay in the queue forever.  If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>

using System;
using System.Collections.Generic;

public class TakingTurnsQueue
{
    private readonly Queue<Person> _queue = new Queue<Person>();

    /// <summary>
    /// Current number of people in the queue.
    /// Exhausted finite players are not kept in the queue.
    /// </summary>
    public int Length => _queue.Count;

    /// <summary>
    /// Enqueue a person at the tail of the queue.
    /// </summary>
    public void AddPerson(string name, int turns)
    {
        _queue.Enqueue(new Person(name, turns));
    }

    /// <summary>
    /// Dequeue the next person. If they still have turns left (after consuming one), re-enqueue.
    /// Infinite players (turns <= 0) are always re-enqueued, and their Turns value is never modified.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_queue.Count == 0)
            throw new InvalidOperationException("No one in the queue.");

        var person = _queue.Dequeue();

        // Infinite players: always re-enqueue; do not change 'Turns'.
        if (person.HasInfiniteTurns)
        {
            _queue.Enqueue(person);
        }
        else
        {
            // Finite players: consume one turn; re-enqueue only if they still have turns left.
            person.UseTurn();
            if (person.Turns > 0)
            {
                _queue.Enqueue(person);
            }
        }

        return person;
    }
}
