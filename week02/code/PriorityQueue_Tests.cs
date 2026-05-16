using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue items with different priorities, then dequeue in order of highest priority.
    // Expected Result: Dequeue returns values in priority order (5, 3, 1), not enqueue order.
    // Defect(s) Found: Loop did not check the last element; item was not removed from the queue after dequeue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("high", 5);
        priorityQueue.Enqueue("mid", 3);

        Assert.AreEqual("high", priorityQueue.Dequeue());
        Assert.AreEqual("mid", priorityQueue.Dequeue());
        Assert.AreEqual("low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Multiple items share the highest priority; dequeue should follow FIFO among ties.
    // Expected Result: "first" is removed before "second" when both have priority 5.
    // Defect(s) Found: Used >= instead of > when comparing priority, so the later tie replaced the earlier one.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 5);
        priorityQueue.Enqueue("second", 5);
        priorityQueue.Enqueue("third", 1);

        Assert.AreEqual("first", priorityQueue.Dequeue());
        Assert.AreEqual("second", priorityQueue.Dequeue());
        Assert.AreEqual("third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None (empty-queue handling was already correct).
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                    e.GetType(), e.Message)
            );
        }
    }

    [TestMethod]
    // Scenario: Enqueue always adds to the back; lower-priority items remain until higher ones are removed.
    // Expected Result: After one dequeue, the remaining queue order reflects FIFO at the back.
    // Defect(s) Found: Failing to remove dequeued items left stale entries in the queue.
    public void TestPriorityQueue_EnqueueToBack()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("a", 1);
        priorityQueue.Enqueue("b", 2);
        priorityQueue.Enqueue("c", 1);

        Assert.AreEqual("b", priorityQueue.Dequeue());
        Assert.AreEqual("a", priorityQueue.Dequeue());
        Assert.AreEqual("c", priorityQueue.Dequeue());
    }
}
