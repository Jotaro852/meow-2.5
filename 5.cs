using System;
using System.Collections.Generic;
using System.Linq;// фильтрация, сортровка данных масива
class work_2_5
{
  static void Main()
    {
        float[,] temperatures = new float[12, 30]; // двуменрый массив
        Random rand = new Random(); // объявляем генератор

        // заполнение массива
        for (int iRow = 0; iRow < 12; iRow++)
        {
            //зима
            if (iRow <= 2) // с [0-2, ...]
                for (int iCol = 0; iCol < 30; iCol++) 
                {
                    temperatures[iRow, iCol] = rand.Next(-35, 1); // заполняем массив
                }
            // весна-осень
            else if (iRow <= 8) // с [3-8, ...]
            { 
                for (int iCol = 0; iCol < 30; iCol++)
                {
                    temperatures[iRow, iCol] = rand.Next(-5, 15); // заполняем массив
                }
            }
            // лето
            else // с [9-11, ...]
            {
                for (int iCol = 0; iCol < 30; iCol++) 
                {
                    temperatures[iRow, iCol] = rand.Next(10, 35); // заполняем массив
                }
            }
        }

        Dictionary<string, float[]> monthlyAverages = CalculateМedium(temperatures); // вычисление средних температур с помощью метода

        Console.WriteLine("Средние температуры по месяцам:");
        foreach (var kvp in monthlyAverages) // перебираем словарь
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value[0]}"); // kvp.Key - ключ, kvp.Value[0] - значение.
        }
    } 

    // Метод для вычисления средней температуры в каждом месяце
    static Dictionary<string, float[]> CalculateМedium(float[,] temperatures)
    {
        int months = temperatures.GetLength(0); // месяца
        int days = temperatures.GetLength(1); // дни

        Dictionary<string, float[]> monthlyAverages = new Dictionary<string, float[]>(); // словарь для средних температур(ключ = название, массив = значение)

        string[] monthNames = {"Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"}; // массив для использования ключей

        // перевоб каждого месяца
        for (int iRow = 0; iRow < months; iRow++)
        {
            float sum = 0; // сумма = 0

            // Перебор каждого дня в месяце
            for (int iCol = 0; iCol < days; iCol++)
            {
                sum += temperatures[iRow, iCol]; // складываем температуры в месяце
            }

            float averageTemperature = sum / days; // средняя температура в месяц

            monthlyAverages.Add(monthNames[iRow], new float[] { averageTemperature }); // Добавляем в словарь месяц и среднюю температуру
        }

        return monthlyAverages; // возвращаем готовый словарь
    }
}
