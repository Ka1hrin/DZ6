using System;
using System.Collections.Generic;
using Bibliotek;

namespace PDF6
{
    public class Pawnshop
    {
        private string _name;
        private string _address;
        private string _phoneNumber;
        private List<Goods> _goods;
        private decimal _balance;
        private decimal _commissionRate;

        /// <summary>
        /// Конструктор ломбарда
        /// </summary>
        public Pawnshop(string name, string address, string phoneNumber, List<Goods> goods, decimal balance, decimal commissionRate)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            _goods = goods;
            Balance = balance;
            CommissionRate = commissionRate;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Строка не может быть пустой!");
                _name = value;
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Строка не может быть пустой!");
                _address = value;
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Строка не может быть пустой!");
                _phoneNumber = value;
            }
        }
        public List<Goods> Goods
        {
            get { return _goods; }
        }

        public decimal Balance
        {
            get { return _balance; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Баланс не может быть отрицательным!");
                _balance = value;
            }
        }

        private decimal CommissionRate
        {
            get { return _commissionRate; }
            set
            {
                if (value < 0 || value > 1)
                    throw new ArgumentException("Множитель не может быть меньше 0 или больше 1!");
                _commissionRate = value;
            }
        }

        /// <summary>
        /// Метод, который печатает информацию про все предметы
        /// </summary>
        public void PrintAllGoods()
        {
            Console.WriteLine($"\nСписок предметов в ломбарде '{Name}':\n");

            if (_goods.Count == 0)
            {
                Console.WriteLine("В ломбарде пока нет вещей!");
                return;
            }

            foreach (var item in _goods)
            {
                item.PrintInfo();
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Метод добавляет предметы в ломбард
        /// </summary>
        public void AcceptItem(Goods item)
        {
            if (item == null)
                throw new ArgumentException("Нельзя принять несуществующий предмет!");

            if (item is Electronics electronics && electronics.IsBroken())
                throw new ArgumentException("Сломанную технику не принимаем!");
            
            if (Balance - item.CalculateCredit() < 0)
                throw new ArgumentException("Извините, в ломбарде нет столько наличных(");

            _goods.Add(item);
            Balance -= item.CalculateCredit();

            Console.WriteLine($"Предмет '{item.NameOfGoods}' успешно принят в залог!");

        }

        /// <summary>
        /// Метод принимает предмет в ломбард и сообщает об ошибке, не останавливая программу
        /// </summary>
        public void TryAcceptItem(Goods item)
        {
            try
            {
                AcceptItem(item);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        /// <summary>
        /// Метод, который продает просроченный по сроку предмет
        /// </summary>
        public void BuyItem(Goods item)
        {
            if (!item.IsExpired())
                throw new ArgumentException("Вещь еще нельзя продать");

            item.Status = Status.Redeemed;
            decimal price = item.CalculateCredit();

            Balance += price * 2;

            _goods.Remove(item);

            Console.WriteLine($"Предмет куплен! Клиент заплатил {price * 2} руб.");
        }
        /// <summary>
        /// Метод, который удаляет предметы, если их выкупили
        /// </summary>
        public void RedeemItem(Goods item)
        {
            if (!_goods.Contains(item))
                throw new ArgumentException("Нельзя выкупить несуществующий предмет!");
            if (item.IsExpired())
                throw new ArgumentException("Нельзя выкупить просроченный предмет!");
            item.Status = Status.Redeemed;

            decimal loanAmount = item.CalculateCredit();    //Сколько мы заплатили за предмет
            decimal interest = loanAmount * CommissionRate * (30 - item.PeriodOfStorange());     //Сколько накапало процентов
            Balance += loanAmount + interest;

            _goods.Remove(item);

            Console.WriteLine($"Предмет выкуплен! Клиент заплатил {loanAmount + interest} руб.");
        }

        /// <summary>
        /// Метод, который выводит предметы определенного статуса
        /// </summary>
        public void PrintGoodsByStatus(Status status)
        {

            Console.WriteLine($"\nПредметы в статусе '{Type.EnumName(status)}'\n");
            foreach (var item in _goods)
            {
                item.UpdateStatus();

                if (item.Status != status)
                    continue;
                item.PrintInfo();
            }
        }

        /// <summary>
        /// Метод, который пополняет баланс ломбарда
        /// </summary>
        public decimal AddCash(decimal value)
        {
            Helper.ThrowException(value);
            Balance += value;
            Console.WriteLine($"Вы успешно пополнили баланс! Текущий баланс: {Balance}\n");
            return Balance;
        }

        /// <summary>
        /// Метод, который выводит баланс ломбарда
        /// </summary>
        public void PrintBalance()
        {
            Console.WriteLine($"\nОстаток на счете: {_balance}\n");
        }

        /// <summary>
        /// Метод, который печатает информацию про ломбард
        /// </summary>
        public void PrintPawnshop()
        {
            Console.WriteLine($"Информация о ломбарде\nНазвание: {_name}\nАдрес: {_address}\nНомер телефона: {_phoneNumber}\n");
        }
    }
}