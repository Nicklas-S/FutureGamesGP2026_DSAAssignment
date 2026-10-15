using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TaskQueue<T> {
    public List<T> Taskqueue = new();

    public void Enqueue(T InNewElement) {
        Taskqueue.Add(InNewElement);
    }

    public T Peek() {
        if(Taskqueue.Count == 0) throw new Exception("Task queue is empty. You can't view tasks that does not exist");

        return Taskqueue[0];
    }

    public T DeQueue() {
        if(Taskqueue.Count == 0) throw new Exception("Task queue is empty, what are you trying to remove?");

        T firstInQueue = Taskqueue[0];
        Taskqueue.RemoveAt(0);
        return firstInQueue;
    }

    public void ClearTasks() {
        Taskqueue.Clear();
    }
}
