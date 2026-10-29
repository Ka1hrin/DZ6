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

        //Полный конструктор, т.е мы знаем все данные о предмете
        public Jewelry(string name, string nameClient, Status status, MetalType metal, double weight, int purity, List<double> stone)
        
            :base(name, nameClient, status)
        {
            Metal = metal;
            Weight = weight;
            Purity = purity;
            Stone = stone;

            CalculateCredit();
        }

        //Предмет по усмотрению
        public Jewelry(string name, double weight)
            :base(name, "Неизвестный клиент", Status.Expired, DateTime.Now.AddDays(-31))
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
                _stone = value;
            }
        }

        /// <summary>
        /// Метод, который считает стоимость камней, если есть
        /// </summary>
        public decimal StonePrice()
        {
            decimal allPrice = 0;

            foreach (double carat in Stone)
            {
                allPrice += (decimal)carat * 10000m;
            }

            return allPrice;
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
                    cost = (decimal)_weight*3000; 
                    break;
                case MetalType.Silver:
                    cost = (decimal)_weight * 50;
                    break;
                case MetalType.Platinum:
                    cost = (decimal)_weight * 4000;
                    break;
                default:
                    cost = (decimal)_weight * 100;
                    break;
            }

            Cost = cost + StonePrice();

            return Cost*0.7m;
        }

        /// <summary>
        /// Дополнили метод печати
        /// </summary>
        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($"Тип металла: {Type.EnumName(_metal)}\nПроба: {_purity}\nВес: {_weight}\nСтоимость: {CalculateCredit()}\n");
        }

    }
}
