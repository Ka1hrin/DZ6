using Bibliotek;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace PDF6
{
    class PDF6
    {
        private static void Main()
        {
            string pathfile = "Text/Pawnshop.txt";

            Pawnshop pawnshop = new Pawnshop("Точно не скам", "ул. Пушкина, дом. 67", "+78002286767", new List<Goods>(), 100000m, 0.1m);
            pawnshop.PrintPawnshop();

            Electronics phone = new Electronics("Телефон", "Лалакова Азиля", Status.Expired, DateTime.Now.AddDays(-20), "Самсунг 2098А", 2000, 50000m, Condition.Good);
            Electronics laptop = new Electronics("Ноутбук", "Казачков Алексей", Status.Expired, DateTime.Now.AddDays(-115), "HP", 2023, 70000m, Condition.Excellent);
            Electronics iphone = new Electronics("Телефон", "Семенова Регина", Status.Expired, DateTime.Now.AddDays(-58), "Iphone 17", 2025, 100000m, Condition.Fair);
            Jewelry ring = new Jewelry("Кольцо", 2);
            Jewelry earrings = new Jewelry("Серьги", 2);
            Electronics vinyl = new Electronics("Виниловый проигрыватель", "Неизвестно");
            pawnshop.AcceptItem(phone);
            pawnshop.AcceptItem(laptop);
            pawnshop.AcceptItem(iphone);
            pawnshop.AcceptItem(ring);
            pawnshop.AcceptItem(earrings);
            pawnshop.AcceptItem(vinyl);

            pawnshop.PrintBalance();
            pawnshop.AddCash(100000m);

            pawnshop.PrintAllGoods();

            ReadFile.LoadJewels(pathfile, pawnshop);

            pawnshop.PrintAllGoods();
            pawnshop.PrintBalance();

            Console.WriteLine("======Меню покупателя======\n1.Выкупить свой предмет\n2.Список доступных для покупки предметов\n0.Выход\n");
            byte number = Helper.ReadBytes("Введите цифру: ");
            Menu.User(number, pawnshop);
        }
    }  
}
