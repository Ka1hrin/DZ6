using System;
using System.IO;
using System.Globalization;

namespace PDF6
{
    public static class ReadFile
    {
        /// <summary>
        /// Метод, который загружает данные из файла с драгоценностями
        /// </summary>
        public static void LoadJewels(string pathfile, Pawnshop pawnshop)
        {
            if (!File.Exists(pathfile))
                throw new ArgumentException($"Файл {pathfile} не найден!");

            //Создаем массив, в котором будем хранить элементы файла
            string[] lines = File.ReadAllLines(pathfile);

            foreach (var line in lines)
            {
                //Создаем массив, который хранит элементы строки, разделив их по символу ";"
                string[] parts = line.Split(';');

                //Проверяем, что все 6 элементов в массиве
                if (parts.Length == 6)
                {
                    //Присваиваем переменным значения из массива
                    string name = parts[0];
                    string clientName = parts[1];

                    if (!Enum.TryParse(parts[2], true, out MetalType metal))
                        throw new ArgumentException("Некорректное значение!");
                    if (!double.TryParse(parts[3], NumberStyles.Any, CultureInfo.InvariantCulture, out var carat))
                        throw new ArgumentException("Некорректное значение!");
                    if (!int.TryParse(parts[4], out var purity))
                        throw new ArgumentException("Некорректное значение!");

                    //Создаем лист с драгоценными камнями
                    List<double> stones = new List<double>();

                    if (!string.IsNullOrWhiteSpace(parts[5]))
                    {
                        //Создаем массив камней 
                        string[] stone = parts[5].Split(",");

                        foreach (var item in stone)
                        {
                            if (!double.TryParse(item, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
                            {
                                Console.WriteLine($"Данный элемент '{item}' не является верным!");
                            }
                            else
                            {
                               
                                stones.Add(result);
                            }
                        }
                    }

                    //Создаем объект в листе с драгоценностями
                    Jewelry stoneInFile = new Jewelry(name, clientName, Status.Pledged, metal, carat, purity, stones);

                    try
                    {
                        pawnshop.AcceptItem(stoneInFile);
                    }
                    catch(ArgumentException ex)
                    {
                        Console.WriteLine($"Предмет '{name}' не добавлен: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine($"Ошибка в строке: {line}");
                }
            }
        }
    }
}