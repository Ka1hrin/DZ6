using System;

namespace DZ6
{
    class Laba6
    {
        static void Main()
        {
            Task7();
        }
        private static void Task7()
        {
            BankAccount account = new BankAccount(78654568m, TypesOfAccount.Savings);
            account.PrintInfo();
            account.Deposit(366472);
            account.PrintInfo();
            account.Withdraw(37289);
            account.PrintInfo();

        }






    }
}