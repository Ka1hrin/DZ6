using System;
using Bibliotek;

namespace DZ6
{
    class Laba6
    {
        private static void Main()
        {
            Task();
            Homework();
        }
        private static void Task()
        {
            Console.WriteLine("Упражнение 7");

            decimal value = Helper.ReadDecimal("Введите баланс: ");
            Console.Write("Введите тип счета:");
            string typesOfAccount = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(typesOfAccount))
                throw new ArgumentException("Строка не может быть пустой!");
            if (!Enum.TryParse(typesOfAccount, true, out TypesOfAccount type))
                throw new ArgumentException("Вы ввели некорректный тип счета!");


            BankAccount account = new BankAccount(value, type);
            account.PrintInfo();

            int deposit = Helper.ReadInt("Введите сумму пополнения: ");
            account.Deposit(deposit);
            account.PrintInfo();

            int withdraw = Helper.ReadInt("Введите сумму, которую хотите снять: ");
            account.Withdraw(withdraw);
            account.PrintInfo();

        }

        private static void Homework()
        {
            int height = Helper.ReadInt("Введите высоту здания: ");
            byte floors = Helper.ReadBytes("Введите количество этажей: ");
            int flats = Helper.ReadInt("Введите количество квартир: ");
            byte entrances = Helper.ReadBytes("Введите количество подъездов: ");

            House house = new House(height, floors, flats, entrances);
            house.PrintInfo();
        }
    }
}