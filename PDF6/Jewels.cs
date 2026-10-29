using System;
using System.Collections.Generic;
using Bibliotek;

namespace PDF6
{
    public class Jewelry : Goods
    {
        private MetalType _metal;
        private double _weight;
        private int _purity;
        private List<double> _stone;

        /// <summary>
        /// Полный конструктор
        /// </summary>
        public Jewelry(string name, string nameClient, Status status, MetalType metal, double weight, int purity, List<double> stone)

            : base(name, nameClient, status)
        {
            Metal = metal;
            Weight = weight;
            Purity = purity;
            Stone = stone;

            CalculateCredit();
        }

        /// <summary>
        /// Конструктор, если о предмете ничего не известно
        /// </summary>
        public Jewelry(string name, double weight)
            : base(name, "Неизвестный клиент", Status.Expired, DateTime.Now.AddDays(-31))
        {
            Metal = MetalType.Gold;
            Weight = weight;
            Purity = 585;
            Stone = new List<double>();
        }

        public MetalType Metal
        {
            get { return _metal; }
            set
            {
                if (!Enum.IsDefined(typeof(MetalType), value))
                    throw new ArgumentException("Некорректное значение!");
                _metal = value;
            }
        }

        public double Weight
        {
            get { return _weight; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Вес не может быть отрицательным!");
                _weight = value;
            }
        }

        public int Purity
        {
            get { return _purity; }
            set
            {
                if (value <= 0 || value > 1000)
                    throw new ArgumentException("Проба не может быть отрицательной и больше 1000!");
                _purity = value;
            }
        }

        public List<double> Stone
        {
            get { return _stone; }
            set
            {
                if (value == null)
                    _stone = new List<double>();
                else
                    _stone = value;
            }
        }

        /// <summary>
        /// Метод считает содержание металла в драгоценности
        /// </summary>
        public decimal PurityCoefficient()
        {
            return _purity / 1000m;
        }
        /// <summary>
        /// Метод, который считает стоимость камней, если есть
        /// </summary>
        public decimal StonePrice()
        {
            if (!HasStone())
            {
                return 0;
            }
            else 
            {
                decimal allPrice = 0;

                foreach (double carat in Stone)
                {
                    allPrice += (decimal)carat * 10000m;
                }

                return allPrice;
            }
        }

        /// <summary>
        /// Задали метод расчета стоимости
        /// </summary>
        public override decimal CalculateCredit()
        {
            decimal cost = 0;

            switch (_metal)
            {
                case MetalType.Gold:
                    cost = (decimal)_weight * 3000 * PurityCoefficient();
                    break;
                case MetalType.Silver:
                    cost = (decimal)_weight * 50 * PurityCoefficient();
                    break;
                case MetalType.Platinum:
                    cost = (decimal)_weight * 4000 * PurityCoefficient();
                    break;
                default:
                    cost = (decimal)_weight * 100 * PurityCoefficient();
                    break;
            }

            Cost = cost + StonePrice();

            return Cost * 0.7m;
        }

        /// <summary>
        /// Метод печати информации о предмете (драгоценность)
        /// </summary>
        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Тип металла: {Type.EnumName(_metal)}\nПроба: {_purity}\nВес: {_weight}\nСтоимость: {CalculateCredit()}\n");
        }

        /// <summary>
        /// Метод, который проверяет вещь на наличие камней
        /// </summary>
        public bool HasStone()
        {
            if (Stone.Count == 0)
                return false;
            else
                return true;
        }
    }
}
