using Bibliotek;
using System;
using System.Globalization;

namespace PDF6
{
    public abstract class Goods
    {
        private string _nameOfGoods;        //Название предмета
        private decimal _cost;              //Оценочная стоимость предмета
        private DateTime _dateOfSub;        //Дата сдачи предмета
        private int _periodOfStorange;      //Количество дней в залоге
        private Status _status;             //Состояние на момент сдачи
        private string _nameClient;         //фИО человека, сдавшего предмет

        //Создаю конструктор, который смогут вызывать наследники
        protected Goods(string name, string nameClient, Status status) 
        {
            NameOfGoods = name;
            _dateOfSub = DateTime.Now;
            _periodOfStorange = PeriodOfStorange();
            Status = status;
            NameClient = nameClient;
        }

        //Конструктор, в котором можно ввести дату продажи
        protected Goods(string name, string nameClient, Status status, DateTime dateOfSub)
        {
            NameOfGoods = name;
            DateOfSub = dateOfSub;
            _periodOfStorange = PeriodOfStorange();
            Status = status;
            NameClient = nameClient;
        }

        /// <summary>
        /// Метод, который рассчитывает количество дней в залоге
        /// </summary>
        public int PeriodOfStorange()
        {
            TimeSpan periodOfStorange = DateTime.Now - _dateOfSub;
            if (30 - periodOfStorange.Days < 0)
                return 0;
            return 30 - periodOfStorange.Days;
        }

        /// <summary>
        /// Метод, который проверяет срок хранения
        /// </summary>
        public void ExpiryDate()
        {
            DateTime expiryDate = _dateOfSub.AddDays(30);

            if (DateTime.Now > expiryDate)
                Console.WriteLine("Срок хранения истек!");
            
            Console.WriteLine($"Осталось дней для выкупа: {PeriodOfStorange()}");
        }

        /// <summary>
        /// Метод рассчитывает, сколько получит клиент
        /// </summary>
        public abstract decimal CalculateCredit();      

        /// <summary>
        /// Метод, который выводит информацию о предмете 
        /// </summary>
        public virtual void PrintInfo()
        {
            Console.WriteLine($"Информация о предмете\nНазвание предмета: {_nameOfGoods}\nКто сдал предмет: {_nameClient}\n" +
                $"Оставшееся время для выкупа: {PeriodOfStorange()} дней\nСтатус: {Type.EnumName(_status)}");
        }

        public string NameOfGoods
        {
            get { return _nameOfGoods; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название не может быть пустым");
                _nameOfGoods = value;
            }
        }

        public Status Status
        {
            get { return _status; }
            set
            {
                //Enum.IsDefined() - есть ли в перечислении, typeof(...) - в каком перечислении, value - что именно
                if (!Enum.IsDefined(typeof(Status), value)) 
                    throw new ArgumentException("Недопустимый статус предмета!");
                _status = value;
            }
        }

        public string NameClient
        {
            get { return _nameClient; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("ФИО не может быть пустым");
                _nameClient = value;
            }
        }

        public decimal Cost
        {
            get { return _cost; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Стоимость не может быть отрицательной!");
                _cost = value;
            }
        }

        public DateTime DateOfSub
        {
            get { return _dateOfSub; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Дата сдачи не может быть в будущем!");

                _dateOfSub = value;
            }
        }
    }
}