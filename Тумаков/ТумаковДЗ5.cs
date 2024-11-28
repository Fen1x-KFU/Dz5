using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;



public class Value
{
    public char[] russianVowels { get; } = { 'А', 'а', 'Е', 'е', 'Ё', 'ё', 'И', 'и', 'О', 'о', 'У', 'у', 'Э', 'э', 'Ы', 'ы', 'Ю',
    'ю', 'Я', 'я' };

    public char[] russianConsonants { get; } = { 'Б', 'б', 'В', 'в', 'Г', 'г', 'Д', 'д', 'Ж', 'ж', 'З', 'з', 'Й', 'й', 'К', 'к',
    'Л', 'л', 'М', 'м', 'Н', 'н', 'П', 'п', 'Р', 'р', 'С', 'с', 'Т', 'т', 'Ф', 'ф', 'Х', 'х', 'Ц', 'ц', 'Ч', 'ч',
    'Ш', 'ш', 'Щ', 'щ' };

    public string file = "Тумаков.txt";
}


public partial class Program
{
    static void StartTask(string n)
    {
        Console.WriteLine($"Задание: {n}");
    }

    static void MatrixWrite(int[,] myaRRay)
    {
        for (int k = 0; k < myaRRay.GetLength(0); k++)
        {
            for (int j = 0; j < myaRRay.GetLength(1); j++)
            {
                Console.Write(myaRRay[k, j] + "\t"); // Вывод элемента массива с табуляцией
            }
            Console.WriteLine(); // Переход на новую строку для следующей строки
        }
    }

    static int[,] MatrixMult(int[,] aRay1, int[,] aRay2, ref int[,] naRay)
    {
        for (int j = 0; j < aRay1.GetLength(0); j++)
        {
            for (int k = 0; k < aRay1.GetLength(1); k++)
            {
                naRay[j, k] = aRay1[j, k] * aRay2[j, k];
            }
        }

        return naRay;
    }

    static double[] MediunTemp(double[,] temp)
    {
        double[] mediumT = new double[12];

        Random random = new Random();

        double medznach = 0.0;

        for (int i = 0; i < temp.GetLength(0); i++)
        {
            for (int j = 0; j < temp.GetLength(1); j++)
            {
                temp[i, j] = random.NextDouble() * (38 - (-48)) + (-48);
            }

            medznach = 0;

            for (int j = 0; j < temp.GetLength(1); j++)
            {
                medznach = medznach + temp[i, j];
            }

            mediumT[i] = Math.Round(medznach / 30, 2);
        }

        return mediumT;
    }

    static LinkedList<LinkedList<int>> CreateMatrix(int rows, int cols)
    {
        LinkedList<LinkedList<int>> matrix = new LinkedList<LinkedList<int>>();
        Random random = new Random();

        for (int i = 0; i < rows; i++)
        {
            LinkedList<int> row = new LinkedList<int>();
            for (int j = 0; j < cols; j++)
            {
                row.AddLast(random.Next(1, 10)); // Генерация случайных чисел от 1 до 10
            }
            matrix.AddLast(row);
        }

        return matrix;
    }

    static void PrintMatrix(LinkedList<LinkedList<int>> matrix)
    {
        foreach (LinkedList<int> row in matrix)
        {
            foreach (int cell in row)
            {
                Console.Write(cell + " ");
            }
            Console.WriteLine();
        }
    }

    static LinkedList<int> MultLinkedLists(LinkedList<int> matrix1, LinkedList<int> matrix2)
    {
        LinkedList<int> multList = new LinkedList<int>();

        LinkedListNode<int> node1 = matrix1.First;
        LinkedListNode<int> node2 = matrix2.First;

        while (node1 != null && node2 != null)
        {
            multList.AddLast(node1.Value * node2.Value);
            node1 = node1.Next;
            node2 = node2.Next;
        }
        return multList;
    }

    static void Task1(string file, char[] lettersVowels, char[] lettersConsonants)
    {
        StartTask("6.1");

        Console.WriteLine("Введите текст для добавления в файл:");
        string textToAdd = Console.ReadLine();

        using (StreamWriter streamWriter = File.AppendText(file)) // Открываем файл для добавления текста
        {
            streamWriter.WriteLine(textToAdd); // Добавляем введенный текст в файл
        }

        string content = File.ReadAllText(file); //Читаем файл

        char[] mayArray = content.ToCharArray();

        int peremv = 0;
        int peremc = 0;

        foreach (char c in mayArray)
        {
            if (lettersVowels.Contains(c))
            {
                peremv++;
            }
            else if (lettersConsonants.Contains(c))
            {
                peremc++;
            }
        }

        Console.WriteLine($"Кол-во гласных = {peremv}");
        Console.WriteLine($"Кол-во согласных = {peremc}");

        File.WriteAllText(file, "");
    }

    static void Task2()
    {
        StartTask("6.2");

        Console.WriteLine("Введите число для определения кол-ва строк и столбцов в матрице.\n Будем считать, что матрица имеет форму квадрата!");

        Console.WriteLine("Введите число для определения кол-ва строк и столбцов в первой и второй матриеце.");
        int num = int.Parse(Console.ReadLine());

        int[,] myaRRay1 = new int[num, num];
        int[,] myaRRay2 = new int[num, num];

        for (int j = 0; j < num; j++)
        {
            for (int k = 0; k < num; k++)
            {
                Console.WriteLine($"Введите числа для первой матрицы {j + 1} столбца и {k + 1} строки.");
                myaRRay1[j, k] = int.Parse(Console.ReadLine());
                Console.WriteLine($"Теперь введите числа для второй матрицы {j + 1} столбца и {k + 1} строки.");
                myaRRay2[j, k] = int.Parse(Console.ReadLine());
            }
        }

        int[,] newArray = new int[num, num];

        MatrixWrite(MatrixMult(myaRRay1, myaRRay2, ref newArray));
    }

    static void Task3()
    {
        StartTask("6.3");

        Console.WriteLine("Сейчас мы сгенерируем температуру на Марсе!");

        double[,] temperature = new double[12, 30];

        double[] newArray = MediunTemp(temperature);
        Array.Sort(newArray);

        Console.WriteLine("Выведем все температуры за год в порядке возрастания!");
        Console.WriteLine();

        for (int i = 0; i < newArray.Length; i++)
        {
            Console.Write(newArray[i] + " ");
        }
        Console.WriteLine();
    }

    static void Task4(string file, char[] lettersVowels, char[] lettersConsonants)
    {
        StartTask("6.1");

        Console.WriteLine("Введите текст для добавления в файл:");
        string textToAdd = Console.ReadLine();

        using (StreamWriter streamWriter = File.AppendText(file)) // Открываем файл для добавления текста
        {
            streamWriter.WriteLine(textToAdd); // Добавляем введенный текст в файл
        }

        string content = File.ReadAllText(file); //Читаем файл

        char[] mayArray = content.ToCharArray();

        int peremv = 0;
        int peremc = 0;

        List<char> listVowels = new List<char>(lettersVowels);
        List<char> listConsonants = new List<char>(lettersConsonants);

        foreach (char c in mayArray)
        {
            if (listVowels.Contains(c))
            {
                peremv++;
            }
            else if (listConsonants.Contains(c))
            {
                peremc++;
            }
        }

        Console.WriteLine($"Кол-во гласных = {peremv}");
        Console.WriteLine($"Кол-во согласных = {peremc}");

        File.WriteAllText(file, "");
    }

    static void Task5()
    {
        StartTask("6.2");

        Console.WriteLine("Введите число, кол-во столбиков и строк в матрице!");
        int len = int.Parse(Console.ReadLine());

        LinkedList<LinkedList<int>> matrix1 = CreateMatrix(len, len);
        LinkedList<LinkedList<int>> matrix2 = CreateMatrix(len, len);

        Console.WriteLine("Выведем первую матрицу");
        PrintMatrix(matrix1);
        Console.WriteLine();
        Console.WriteLine("Выведем вторую матрицу");
        PrintMatrix(matrix2);
        Console.WriteLine();

        LinkedList<LinkedList<int>> newmatrix = new LinkedList<LinkedList<int>>();

        for (int i = 0; i < len; i++)
        {
            if (i < matrix1.Count && i < matrix2.Count)
            {
                LinkedList<int> row1 = matrix1.ElementAt(i);
                LinkedList<int> row2 = matrix2.ElementAt(i);

                newmatrix.AddLast(MultLinkedLists(row1, row2));
            }
        }

        Console.WriteLine("Выведем произведение двух матриц");
        PrintMatrix(newmatrix);
    }

    static void Task6()
    {
        StartTask("6.3");

        Console.WriteLine("Давайте сгенерируем температуру на Марсе 2 раз!");

        double[,] temperature = new double[12, 30];

        double[] newArray = MediunTemp(temperature);
        Console.WriteLine($"{newArray[0]}  {newArray[1]}");

        Dictionary<string, int> dict = new Dictionary<string, int>
    {
        {"Январь", 0 },
        {"Февраль", 1 },
        {"Март", 2 },
        {"Апрель", 3 },
        {"Май", 4 },
        {"Июнь", 5 },
        {"Июль", 6 },
        {"Август", 7 },
        {"Сентябрь", 8 },
        {"Октябрь", 9 },
        {"Ноябрь", 10 },
        {"Декабрь", 11 }
    };

        Dictionary<string, double> sesons = new Dictionary<string, double>();


        foreach (var kvp1 in dict)
        {
            sesons.Add(kvp1.Key, newArray[kvp1.Value]);
        }

        Console.WriteLine("Выведем всю температуру за год!");

        foreach (var kvp2 in sesons)
        {
            Console.WriteLine($"Месяц: {kvp2.Key}, Среднее значение: {kvp2.Value} градусов!");
        }
    }

    static void Main()
    {
        Value valuel = new Value();

        Task1(valuel.file, valuel.russianVowels, valuel.russianConsonants);
        Task2();
        Task3();
        Task4(valuel.file, valuel.russianVowels, valuel.russianConsonants);
        Task5();
        Task6();
    }
}
