using System;
using System.ComponentModel.Design;

namespace Bibliotek
{
    public class Helper
    {
        /// <summary>
        /// Метод переводит строку в тип decimal
        /// </summary>
        public static decimal ReadDecimal(string prompt)
        {
            Console.Write(prompt);
            if (!decimal.TryParse(Console.ReadLine(), out decimal result))
                throw new ArgumentException("Вы ввели некорректное значение!");
            return result;
        }

        /// <summary>
        /// Метод переводит строку в тип int
        /// </summary>
        public static int ReadInt(string prompt)
        {
            Console.Write(prompt);
            if (!int.TryParse(Console.ReadLine(), out int result))
                throw new ArgumentException("Вы ввели некорректное значение!");
            return result;
        }

        /// <summary>
        /// Метод переводит строку в тип byte
        /// </summary>
        public static byte ReadBytes(string prompt)
        {
            Console.Write(prompt);
            if (!byte.TryParse(Console.ReadLine(), out byte result))
                throw new ArgumentException("Вы ввели некорректное значение!");
            return result;
        }

        public static string ReadString(string prompt)
        {
            Console.Write(prompt);
            string result = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(result))
                throw new ArgumentException("Строка не может быть пустой!");
            return result;
        }
    }
}
