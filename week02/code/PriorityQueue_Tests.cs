using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Problem 2 - Write and run test cases and fix the code to match requirements.
[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Dequeue on an empty queue.
    // Expected Result: Throws InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None after fix; validates exact exception type and message.
    public void Dequeue_WhenEmpty_ThrowsInvalidOperationException()
    {
        var pq = new PriorityQueue();

        var ex = Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }

    [TestMethod]
    // Scenario: Single item is enqueued; Dequeue should remove and return it.
    // Expected Result: Returned value equals the enqueued item; queue becomes empty ("[]").
    // Defect(s) Found: Original code returned the value but did NOT remove from the list.
    public void Dequeue_WithSingleItem_RemovesAndReturnsItem()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 2);

        var value = pq.Dequeue();
        Assert.AreEqual("A", value);
        Assert.AreEqual("[]", pq.ToString(), "Queue should be empty after removing the single item.");
    }

    [TestMethod]
    // Scenario: Items with different priorities; highest-priority item should be removed.
    // Expected Result: Dequeue returns item with highest priority; remaining order preserved.
    // Defect(s) Found: Original loop bounds skipped the last element and did not remove from queue.
    public void Dequeue_RemovesHighestPriorityItem()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 3);

        var value = pq.Dequeue();
        Assert.AreEqual("B", value, "Should remove the highest-priority item.");
        Assert.AreEqual("[A (Pri:1), C (Pri:3)]", pq.ToString(), "Remaining items should keep their original order.");
    }

    [TestMethod]
    // Scenario: Highest-priority element is at the very back of the queue.
    // Expected Result: Dequeue returns the last item if it has the highest priority.
    // Defect(s) Found: Original loop used 'index < _queue.Count - 1', skipping the last item.
    public void Dequeue_ConsidersLastElementForHighestPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 2);
        pq.Enqueue("C", 9); // Highest priority at the back

        var value = pq.Dequeue();
        Assert.AreEqual("C", value, "Must consider the last element when finding the highest priority.");
        Assert.AreEqual("[A (Pri:1), B (Pri:2)]", pq.ToString());
    }

    [TestMethod]
    // Scenario: Multiple items share the highest priority; must follow FIFO among those.
    // Expected Result: The earliest among highest-priority items is removed first; repeated dequeues keep FIFO.
    // Defect(s) Found: Original code used '>=' which favored later entries (breaking FIFO on ties) and did not remove items.
    public void Dequeue_TiesHonorFIFOAmongHighestPriorityItems()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 5); // earliest of high-priority group
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 4);
        pq.Enqueue("D", 5);

        var first = pq.Dequeue();
        Assert.AreEqual("A", first, "Earliest among the highest priorities should be dequeued first.");
        Assert.AreEqual("[B (Pri:5), C (Pri:4), D (Pri:5)]", pq.ToString());

        var second = pq.Dequeue();
        Assert.AreEqual("B", second, "Next earliest among the remaining highest priorities.");
        Assert.AreEqual("[C (Pri:4), D (Pri:5)]", pq.ToString());

        var third = pq.Dequeue();
        Assert.AreEqual("D", third, "Remaining highest-priority item.");
        Assert.AreEqual("[C (Pri:4)]", pq.ToString());
    }

    [TestMethod]
    // Scenario: Enqueue always appends (back of the queue) regardless of priority.
    // Expected Result: With equal priority values, Dequeue order reflects original insertion order.
    // Defect(s) Found: Covered by the tie/FIFO test; this case emphasizes enqueue semantics.
    public void Enqueue_AddsToBack_IrrespectiveOfPriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("X", 10);
        pq.Enqueue("Y", 10);
        pq.Enqueue("Z", 10);

        Assert.AreEqual("X", pq.Dequeue());
        Assert.AreEqual("Y", pq.Dequeue());
        Assert.AreEqual("Z", pq.Dequeue());
        Assert.AreEqual("[]", pq.ToString());
    }
}

