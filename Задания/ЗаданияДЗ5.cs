using System;
using System.Collections;
using System.Collections.Generic;

public class Graph
{
    private int V; // Количество вершин в графе
    private List<int>[] adj; // Список смежности

    public Graph(int v)
    {
        V = v;
        adj = new List<int>[v];
        for (int i = 0; i < v; i++)
        {
            adj[i] = new List<int>();
        }
    }

    // Добавление ребра в граф
    public void AddEdge(int v, int w)
    {
        adj[v].Add(w);
    }

    // Обход графа в ширину и поиск кратчайшего пути
    public void BFS(int start, int target)
    {
        bool[] visited = new bool[V];
        int[] distance = new int[V];
        int[] parent = new int[V];

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);
        visited[start] = true;
        parent[start] = -1;

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            if (current == target)
            {
                // Вывод кратчайшего пути
                Console.WriteLine("Кратчайший путь:");
                int node = target;
                while (node != -1)
                {
                    Console.Write(node + " ");
                    node = parent[node];
                }
                return;
            }

            foreach (int neighbor in adj[current])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    distance[neighbor] = distance[current] + 1;
                    parent[neighbor] = current;
                    queue.Enqueue(neighbor);
                }
            }
        }

        Console.WriteLine("Путь не найден");
    }
}


public class Program
{
    static void StartTask(string n)
    {
        Console.WriteLine($"Задание {n}");
    }

    static void ShuffleList(List<string> list)
    {
        Random random = new Random();

        List<string> shuffl = list.OrderBy(key => random.Next()).ToList();

        list.Clear();
        list.AddRange(shuffl);
    }

    static void Task1()
    {
        StartTask("1");

        List<string> origListImages = new List<string>();

        for (int i = 1; i <= 32; i++)
        {
            string imagePath = $"image_{i}.jpg";
            origListImages.Add(imagePath);
            origListImages.Add(imagePath);
        }

        Console.WriteLine("Выведем исходный список:");
        for (int i = 0; i < origListImages.Count; i++)
        {
            Console.WriteLine($"Индекс {i}: {origListImages[i]}");
        }

        Console.WriteLine("\nВыведем пермешанный список:");

        List<string> shuffListImages = new List<string>(origListImages);
        ShuffleList(shuffListImages);

        for (int i = 0; i < shuffListImages.Count; i++)
        {
            Console.WriteLine($"Индекс {i}: {shuffListImages[i]}");
        }
    }

    static void Task4()
    {
        StartTask("4");

        Graph graph = new Graph(4);
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 2);
        graph.AddEdge(2, 0);
        graph.AddEdge(2, 3);
        graph.AddEdge(3, 3);

        // Начальная вершина и целевая вершина
        int start = 2;
        int target = 3;

        // Обход графа в ширину и вывод кратчайшего пути
        graph.BFS(start, target);
    }

    static void Main()
    {
        Task1();
        Task4();
    }
}