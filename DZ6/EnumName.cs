using Bibliotek;
using System;

namespace DZ6
{
    public static class BankHelp
    {
        /// <summary>
        /// Метод переводит строку в тип TypesOfAccount
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