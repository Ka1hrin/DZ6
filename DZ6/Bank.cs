using System;

namespace DZ6
{
    public class BankAccount
    {
        private static int _bankId = 0;
        private int _bankNumber;
        private decimal _balance;
        private TypesOfAccount _account;


        public decimal Balance
        {
            get { return _balance; }
        }
        public TypesOfAccount Account
        {
            get { return _account; }
            set { _account = value; }
        }

        private static int BankId()
        {
            return ++_bankId;
        }
        public decimal Withdraw(decimal value)
        {

            if (value > _balance)
                throw new ArgumentException("На счете недостаточно средств");
            _balance -= value;
            return _balance;

        }

        public decimal Deposit(decimal value)
        {

            if (value <= 0)
                throw new ArgumentException("Сумма пополнения должна быть больше нуля");
            _balance += value;
            return _balance;
        }
       
        public BankAccount(decimal balance, TypesOfAccount account)
        {
            _bankNumber = BankId();
            _balance = balance;
            _account = account;
        }
        public void PrintInfo()
        {
            Console.WriteLine($"Номер счета: {_bankNumber}, тип счета: {_account}, баланс: {_balance}\n");
        }
    }
}
