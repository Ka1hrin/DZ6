using Bibliotek;
using System;

namespace DZ6
{
    public static class BankHelp
    {
        /// <summary>
        /// Метод переводит тип TypesOfAccount в строку 
        /// </summary>
        public static string EnumName(TypesOfAccount account)
        {
            return account switch
            {
                TypesOfAccount.Current => "Текущий счет",
                TypesOfAccount.Savings => "Накопительный счет",
                _ => "Неизвестный тип счета!"
            };
        }
    }
}