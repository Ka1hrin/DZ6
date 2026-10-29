using System;
using Bibliotek;

namespace PDF6
{
    public class Electronics : Goods
    {
        private string _model;
        private int _manufactureYear;
        private decimal _marketPrice;
        private Condition _condition;
        private bool HasBox {  get; set; }

        /// <summary>
        /// Полный конструктор (вводится если сдали в залог сегодня)
        /// </summary>
        public Electronics(string name, string clientName, Status status, string model, int manufactureYear, decimal marketPrice, Condition condition, bool hasBox)
            :base (name, clientName, status)
        {
            Model = model;
            ManufactureYear = manufactureYear;
            MarketPrice = marketPrice;
            Condition = condition;
            HasBox = hasBox;
        }

        /// <summary>
        /// Полный конструктор (если предмет сдали не сегодня)
        /// </summary>
        public Electronics(string name, string clientName, Status status, DateTime dateOfSub, string model, int manufactureYear, decimal marketPrice, Condition condition)
            :base(name, clientName, status, dateOfSub)
        {
            Model = model;
            ManufactureYear = manufactureYear;
            MarketPrice = marketPrice;
            Condition = condition;
        }

        /// <summary>
        /// Конструктор, если про предмет ничего не известно
        /// </summary>
        public Electronics(string name, string model)
            : base (name, "Неизвестный клиент", Status.Expired, DateTime.Now.AddDays(-31))
        {
            Model = model;
            ManufactureYear = 2000;
            MarketPrice = 1000;
            Condition = Condition.Fair;
            HasBox = false;
        }
        public string Model
        {
            get { return _model; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Поле не может быть пустым!");
                _model = value;
            }
        }

        public int ManufactureYear
        {
            get { return _manufactureYear; }
            set
            {
                if (value < 1990 || value > DateTime.Now.Year)
                    throw new ArgumentException("Предмет слишком старый или еще не создан!");
                _manufactureYear = value;
            }
        }

        public decimal MarketPrice
        {
            get { return _marketPrice; }
            set
            {
                Helper.ThrowException(value);
                _marketPrice = value;
            }
        }

        public Condition Condition
        {
            get {return _condition;}
            set
            {
                if (!Enum.IsDefined(typeof(Condition), value))
                    throw new ArgumentException("Введено некорректное состояние предмета!");
                _condition = value;
            }
        }

        /// <summary>
        /// Метод, который возвращает процент за состояние
        /// </summary>
        private decimal ConditionPrice()
        {
            switch (_condition)
            {
                case Condition.Excellent: return 0.8m;
                case Condition.Good: return 0.6m;
                case Condition.Fair: return 0.2m;
                case Condition.Broken: return 0;
                default: return 0;
            }
        }

        /// <summary>
        /// Метод, который возвращает процент за возраст
        /// </summary>
        private decimal YearPrice()
        {
            int age = DateTime.Now.Year - _manufactureYear;
            decimal prozent = 1;

            if (age > 2)
            {
                prozent = 1 - (age - 2) * 0.05m;
                return prozent < 0 ? 0.1m : prozent;
            }

            return 1;
        }

        /// <summary>
        /// Метод, который считает сумму, необходимую выдать в залог
        /// </summary>
        public override decimal CalculateCredit()
        {
            decimal prozent = 1;
            if (HasBox)
                prozent += 0.05m;

            decimal cost = _marketPrice * ConditionPrice() * YearPrice() * prozent;
            Cost = cost;
            return Cost;
        }

        /// <summary>
        /// Метод, который печатает информацию о предмете (техника)
        /// </summary>
        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Модель: {_model}\nСостояние: {Type.EnumName(_condition)}\nЗалоговая стоимость: {CalculateCredit()}\n");
        }

        /// <summary>
        /// Метод, проверяющий сломана ли техника
        /// </summary>
        public bool IsBroken()
        {
            if (_condition == Condition.Broken)
                return true;
            else
                return false;
        }
    }
}
