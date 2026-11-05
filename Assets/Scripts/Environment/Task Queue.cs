using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TaskQueue<T> {
    public List<T> taskQueue = new();

    public void Enqueue(T InNewElement) {
        taskQueue.Add(InNewElement);
    }

    public T Peek() {
        if(taskQueue.Count == 0) throw new Exception("Task queue is empty. You can't view tasks that does not exist");

        return taskQueue[0];
    }

    public T DeQueue() {
        if(taskQueue.Count == 0) throw new Exception("Task queue is empty, what are you trying to remove?");

        T firstInQueue = taskQueue[0];
        taskQueue.RemoveAt(0);
        return firstInQueue;
    }

    public void ClearTasks() {
        taskQueue.Clear();
    }
}
