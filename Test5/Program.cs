using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;


public class Program
{
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

    static void Main()
    {
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

        foreach (var kvp2 in sesons)
        {
            Console.WriteLine($"Месяц: {kvp2.Key}, Значение: {kvp2.Value}");
        }
    }
}