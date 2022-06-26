using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        var count = int.Parse(Console.ReadLine());

        var queue = new MyQueue();

        for (int index = 0; index < count; index++)
        {
            var command = Console.ReadLine();
            var parts = command.Split(' ');

            if (parts[0] == "1")
                queue.Enqueue(int.Parse(parts[1]));

            else if (parts[0] == "2")
                queue.Dequeue();

            else if (parts[0] == "3")
                Console.WriteLine(queue.Peek());
        }
    }
}

class MyQueue
{
    //set to new Stack<int>
    Stack<int> PushStack = new Stack<int>();
    Stack<int> PopStack = new Stack<int>();

    public int Dequeue()
    {
        //if condition (==) apply function LoadToPopStack
        if (PopStack.Count == 0) LoadToPopStack();
        //return 
        return PopStack.Pop();
    }
    //int arrow function apply function .Push(int)
    public void Enqueue(int value) => PushStack.Push(value);
    public int Peek()
    {
        //if condition (==) apply function LoadToPopStack()
        if (PopStack.Count == 0) LoadToPopStack();
        //return apply function .Peek()
        return PopStack.Peek();
    }
    void LoadToPopStack()
    {
        //while condition (>)
        while (PushStack.Count > 0)
            //apply function .Push( apply function .Pop())
            PopStack.Push(PushStack.Pop());
    }
}