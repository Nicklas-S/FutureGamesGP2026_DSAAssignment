using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;


public class BSTNode {
    public Employees data;
    public BSTNode leftChild = null;
    public BSTNode rightChild = null;

    public Employees GetData() {
        return data;
    }
    
    public BSTNode(Employees inData) {
        this.data = inData;
    }
}

public class BinaryTree {
    public BSTNode root;
    public BinaryTree(Employees rootData) {
        root = new BSTNode(rootData);
    }

    public void Insert(Employees inData) {
        BSTNode newNode = new BSTNode(inData);
        BSTNode? currentNode = root;
        BSTNode lastParrent = root;

        while(currentNode != null) {
            if(inData.Entered <= currentNode.GetData().Entered) {
                lastParrent = currentNode;
                currentNode = currentNode.leftChild;
            }

            else {
                lastParrent = currentNode;
                currentNode = currentNode.rightChild;
            }
        }

        if(inData.Entered <= lastParrent.GetData().Entered) {
            lastParrent.leftChild = newNode;
        }

        else {
            lastParrent.rightChild = newNode;
        }
    }

    public void DFS(BSTNode root, DateTime first, DateTime second) {
        DateTime start = DateTime.Now;
        Stack<BSTNode> stack = new();
        BSTNode current = root;

        while(current != null || stack.Count > 0) {
            while(current != null) {
                stack.Push(current);
                current = current.leftChild;
            }
            current = stack.Pop();
            if(current.data.Entered.Date >= first && current.data.Entered.Date <= second) Debug.Log("Name: " + current.data.name + "\nID: " + current.data.employeeId +
                "\nLast entered: " + current.data.Entered + "\nExited: " + current.data.Exiting);
            current = current.rightChild;
        }

        DateTime stop = DateTime.Now;
        TimeSpan elapsedTime = stop - start;
        Debug.Log("Elapsed time for DFS: " + elapsedTime.TotalMilliseconds + " ms");
    }

    public void BFS(BSTNode root, DateTime first, DateTime second) {
        DateTime start = DateTime.Now;
        Queue<BSTNode> queue = new Queue<BSTNode>();
        queue.Enqueue(root);

        while(queue.Count > 0 ) {
            BSTNode node = queue.Dequeue();
            if(node.data.Entered.Date >= first && node.data.Entered.Date <= second) Debug.Log("Name: " + node.data.name + "\nID: " + node.data.employeeId +
                "\nLast entered: " + node.data.Entered + "\nExited: " + node.data.Exiting);

            if(node.leftChild != null) {
                queue.Enqueue(node.leftChild);
            }

            if(node.rightChild != null) {
                queue.Enqueue(node.rightChild);
            }
        }
        DateTime stop = DateTime.Now;
        TimeSpan elapsedTime = stop - start;
        Debug.Log("Elapsed time for BFS: " + elapsedTime.TotalMilliseconds + " ms");
    }
}
