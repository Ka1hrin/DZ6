using System;
using Bibliotek;

namespace PDF6
{
    public class Menu
    {
        /// <summary>
        /// Метод, который выводит меню пользователя
        /// </summary>
        public static void User(byte number, Pawnshop pawnshop)
        {
            switch(number)
            {
                case 1:
                    pawnshop.PrintGoodsByStatus(Status.Pledged);
                    string clientName = Helper.ReadString("Введите ваши фамилию и имя: ");
                    string name = Helper.ReadString("Введите название предмета: ");

                    Goods foundItem = null;

                    foreach (var item in pawnshop.Goods)
                    {
                        if (item.NameClient.Equals(clientName, StringComparison.OrdinalIgnoreCase) && item.NameOfGoods.Equals(name, StringComparison.OrdinalIgnoreCase))
                        {
                            foundItem = item;
                            break;
                        }

                    }

                    if (foundItem == null)
                    {
                        Console.WriteLine("Предмет с такими данными не найден!");
                        return;
                    }
                    else
                    {
                        try
                        {
                            pawnshop.RedeemItem(foundItem);
                        }
                        catch(ArgumentException ex) 
                        { 
                            Console.WriteLine(ex.Message); 
                        }
                    }
                    break;
                
                case 2:
                    pawnshop.PrintGoodsByStatus(Status.Expired);
                    string nameOfGoods = Helper.ReadString("Введите название вещи:");

                    Goods goods = null;

                    foreach(var item in pawnshop.Goods)
                    {
                        if (item.NameOfGoods.Equals(nameOfGoods, StringComparison.OrdinalIgnoreCase) && item.Status == Status.Expired)
                        {
                            goods = item;
                            break;
                        }
                    }

                    if (goods == null)
                    {
                        Console.WriteLine("Такой предмет не найден!");
                        return;
                    }
                    else
                    {
                        try
                        {
                            pawnshop.BuyItem(goods);
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message) ;
                        }
                    }
                    break;
                case 0:
                    return;
                default: 
                    throw new ArgumentException("Вы выбрали некорректный вариант!");
            }
        }
    }
}