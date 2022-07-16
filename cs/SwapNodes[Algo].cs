using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    //int[][], int[]
    static int[][] swapNodes(int[][] indexes, int[] queries)
    {
        //set to create new Queue<Node>
        var queue = new Queue<Node>();
        //set to create new Dictionary<int,List<Node>>
        var dic = new Dictionary<int, List<Node>>();
        //set to create new Node
        var root = new Node
        {
            //set to
            Data = 1,
            Level = 1,
        };
        //apply function .Add(1, create new List<Node>{new Node})
        dic.Add(1, new List<Node> { root });
        //apply function Enqueue
        queue.Enqueue(root);
        //set to
        var counter = 0;
        //int, Node
        Func<int, Node, Node> get = (int data, Node current) =>
        {
            //set to != -1? create new Node
            var res = data != -1 ? new Node
            {
                //set to
                Data = data,
                Level = current.Level + 1,
            } : null;
            //if condition (!=)
            if (res != null)
            {
                //if condition (apply function .TryGetValue())
                if (dic.TryGetValue(current.Level + 1, out var list))
                    //apply function .Add()
                    list.Add(res);
                else
                    //apply function .Add(int + 1, new List<Node>{})
                    dic.Add(current.Level + 1, new List<Node> { res });
                //apply function .Enqueue
                queue.Enqueue(res);
            }
            //return
            return res;
        };
        //while condition (>)
        while (queue.Count > 0)
        {
            //set to apply function .Dequeue()
            var current = queue.Dequeue();
            //set to calculate
            var values = indexes[counter++];
            //set to apply function get()
            current.Left = get(values[0], current);
            //set to apply function get()
            current.Right = get(values[1], current);
        }
        //set to create new List<int[]>
        var result = new List<int[]>();
        //foreach condition (int in int[])
        foreach (var query in queries)
            //apply function .Add(apply function .Swap())
            result.Add(Swap(dic, query, root));
        //return apply function .ToArray()
        return result.ToArray();
    }
    //Dictionary<int,List<Node>>, int, Node
    static int[] Swap(Dictionary<int, List<Node>> dic, int query, Node root)
    {
        //set to
        var mul = 1;
        //while condition (int * 1 <=)
        while (query * mul <= dic.Count)
            //if condition (apply fuction .TryGetValue(int * 1++))
            if (dic.TryGetValue(query * mul++, out var list))
                //apply function .ForEach(int => =!)
                list.ForEach(x => x.Toggled = !x.Toggled);
        //set to create new List<int>
        var result = new List<int>();
        //apply function .AddRange(apply function GetForPrint())
        result.AddRange(GetForPrint(root.Left));
        //apply function .Add()
        result.Add(root.Data);
        //apply function .AddRange(apply function .GetForPrint())
        result.AddRange(GetForPrint(root.Right));
        //return apply function .ToArray
        return result.ToArray();
    }
    //Node
    private static IEnumerable<int> GetForPrint(Node node)
    {
        //if condition (==)
        if (node == null) yield break;
        //foreach condition (in apply function GetForPrint())
        foreach (var item in GetForPrint(node.Left))
            //yield return
            yield return item;
        //yield return
        yield return node.Data;
        //foreach condition (in apply function GerForPrint())
        foreach (var item in GetForPrint(node.Right))
            //yield return
            yield return item;
    }
    class Node
    {
        //declare
        Node left;
        Node right;
        public bool Toggled { get; set; }
        public int Level { get; set; }
        public int Data { get; set; }
        public Node Left
        {
            //=> ?
            get => Toggled ? right : left;
            set
            {
                //if condition(bool) set to
                if (Toggled) right = value;
                //else
                else left = value;
            }
        }
        public Node Right
        {
            //=> ?
            get => Toggled ? left : right;
            set
            {
                //if condition (bool) set to
                if (Toggled) left = value;
                //else
                else right = value;
            }
        }
    }
    static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[][] indexes = new int[n][];

        for (int indexesRowItr = 0; indexesRowItr < n; indexesRowItr++)
        {
            indexes[indexesRowItr] = Array.ConvertAll(Console.ReadLine().Split(' '), indexesTemp => Convert.ToInt32(indexesTemp));
        }

        int queriesCount = Convert.ToInt32(Console.ReadLine());

        int[] queries = new int[queriesCount];

        for (int queriesItr = 0; queriesItr < queriesCount; queriesItr++)
        {
            int queriesItem = Convert.ToInt32(Console.ReadLine());
            queries[queriesItr] = queriesItem;
        }

        int[][] result = swapNodes(indexes, queries);

        textWriter.WriteLine(String.Join("\n", result.Select(x => String.Join(" ", x))));

        textWriter.Flush();
        textWriter.Close();
    }
}
