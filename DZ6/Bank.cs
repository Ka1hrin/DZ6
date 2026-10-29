using Bibliotek;
using System;

namespace DZ6
{
    public class BankAccount
    {
        private static int _bankId = 0;
        private int _bankNumber;
        private decimal _balance;
        private TypesOfAccount _account;

        public BankAccount(decimal balance, TypesOfAccount account)
        {
            _bankNumber = BankId();
            Balance = balance;
            Account = account;
        }

        public int BankNumber
        {
            get { return _bankNumber; }
        }
        public decimal Balance
        {
            get { return _balance; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Баланс не может быть отрицательным!");
                _balance = value;
            }
        }

        public TypesOfAccount Account
        {
            get { return _account; }
            set 
            {
                if (!Enum.IsDefined(typeof(TypesOfAccount), value))
                    throw new ArgumentException("Некорректный тип счета!");
                _account = value;
            }
        }

        /// <summary>
        /// Метод считает уникальный номер счета
        /// </summary>
        private static int BankId()
        {
            return ++_bankId;
        }

        /// <summary>
        /// Метод проверяет баланс и снимает деньги со счета
        /// </summary>
        public decimal Withdraw(decimal value)
        {

            if (value > _balance)
                throw new ArgumentException("На счете недостаточно средств");
            Helper.ThrowException(value);
            _balance -= value;
            return _balance;

        }

        /// <summary>
        /// Метод пополняет счет
        /// </summary>
        public decimal Deposit(decimal value)
        {
            Helper.ThrowException(value);
            _balance += value;
            return _balance;
        }
       

        /// <summary>
        /// Метод печатает информацию о счете
        /// </summary>
        public void PrintInfo()
        {
            Console.WriteLine($"Номер счета: {_bankNumber}, тип счета: {BankHelp.EnumName(_account)}, баланс: {_balance}\n");
        }
    }
}
