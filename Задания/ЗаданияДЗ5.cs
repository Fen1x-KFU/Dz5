using System;
using System.Runtime.InteropServices;

//Console.WriteLine("Введите число для определения кол-ва строк и столбцов в матрице.\n Вы вводите число, потому что матрицы должны иметь один размер");

//Console.WriteLine("Введите число для определения кол-ва строк и столбцов в первой и второй матриеце.");
//int i = int.Parse(Console.ReadLine());

//int[,] myaRRay1 = new int[i, i];
//int[,] myaRRay2 = new int[i, i];


//for (int j = 0; j < i; j++)
//{
//    for (int k = 0; k < i; k++)
//    {
//        Console.WriteLine($"Введите числа для первой матрицы {j+1} строки и {k+1} столбца.");
//        myaRRay1[j, k] = int.Parse(Console.ReadLine());
//        Console.WriteLine($"Теперь введите числа для второй матрицы {j+1} строки и {k+1} столбца.");
//        myaRRay2[j,k] = int.Parse(Console.ReadLine());
//    }
//}

//for (int k = 0; k < myaRRay1.GetLength(0); k++)
//{
//    for (int j = 0; j < myaRRay1.GetLength(1); j++)
//    {
//        Console.Write(myaRRay1[k, j] + "\t"); // Вывод элемента массива с табуляцией
//    }
//    Console.WriteLine(); // Переход на новую строку для следующей строки
//}

//Console.WriteLine("Теперь выведем 2 матрицу");

//for (int k = 0; k < myaRRay2.GetLength(0); k++)
//{
//    for (int j = 0; j < myaRRay2.GetLength(1); j++)
//    {
//        Console.Write(myaRRay2[k, j] + "\t"); // Вывод элемента массива с табуляцией
//    }
//    Console.WriteLine(); // Переход на новую строку для следующей строки
//}

int[,] myu = new int[5, 6]
{
    { 5, 6, 7, 8, 7, 8},
    { 5, 6, 7, 8, 7, 8},
    { 5, 6, 7, 8, 8, 7},
    { 5, 6, 7, 8, 8, 7},
    { 5, 6, 7, 8, 8, 7}
};

Console.WriteLine(myu.GetLength(0));