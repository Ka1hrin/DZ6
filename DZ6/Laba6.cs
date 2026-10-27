using System;

namespace DZ6
{
    class Laba6
    {
        static void Main()
        {
            Task();
            Homework();
        }
        private static void Task()
        {
            Console.WriteLine("Упражнение 7");

            BankAccount account = new BankAccount(78654568m, TypesOfAccount.Savings);
            account.PrintInfo();
            account.Deposit(366472);
            account.PrintInfo();
            account.Withdraw(37289);
            account.PrintInfo();

        }

        private static void Homework()
        {
            House house = new House(828, 163, 900, 10);
            house.PrintInfo();
        }
    }
}