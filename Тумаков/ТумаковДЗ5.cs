using System;
using System.IO;
using System.Collections.Generic;



public class Value
{
    public char[] russianVowels { get;  } = { 'А', 'а', 'Е', 'е', 'Ё', 'ё', 'И', 'и', 'О', 'о', 'У', 'у', 'Э', 'э', 'Ы', 'ы', 'Ю',
    'ю', 'Я', 'я' };
    
    public char[] russianConsonants { get;  } = { 'Б', 'б', 'В', 'в', 'Г', 'г', 'Д', 'д', 'Ж', 'ж', 'З', 'з', 'Й', 'й', 'К', 'к',
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

        Console.WriteLine("Введите число для определения кол-ва строк и столбцов в матрице.\nВы вводите число, потому что матрицы должны иметь один размер");

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

    static void Main()
    {
        Value valuel = new Value();

        Task1(valuel.file, valuel.russianVowels, valuel.russianConsonants);
        Task2();
    }
}
