using System;
using Bibliotek;

namespace DZ6
{
    class Laba6
    {
        private static void Main()
        {
            try { Task(); }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try { Homework();}
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        private static void Task()
        {
            Console.WriteLine("Упражнение 7");

            decimal value = Helper.ReadDecimal("Введите баланс: ");
            Console.Write("Введите тип счета (Current, Savings): ");
            string typesOfAccount = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(typesOfAccount) || !Enum.TryParse(typesOfAccount, true, out TypesOfAccount type))
                throw new ArgumentException("Некорректный ввод!");

            BankAccount account = new BankAccount(value, type);
            account.PrintInfo();

            decimal deposit = Helper.ReadDecimal("Введите сумму пополнения: ");
            account.Deposit(deposit);
            account.PrintInfo();

            decimal withdraw = Helper.ReadDecimal("Введите сумму, которую хотите снять: ");
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