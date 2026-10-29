using Bibliotek;
using System;

namespace PDF6
{
    public class Type
    {
        /// <summary>
        /// Метод переводит тип Condition строку 
        /// </summary>
        public static string EnumName(Condition condition)
        {
            return condition switch
            {
                Condition.Excellent => "Отличное",
                Condition.Good => "Хорошее",
                Condition.Fair => "Плохое",
                Condition.Broken => "Сломано"
            };
        }

        /// <summary>
        /// Метод переводит тип MetalType в строку 
        /// </summary>
        public static string EnumName(MetalType metalType)
        {
            return metalType switch
            {
                MetalType.Gold => "Золото",
                MetalType.Silver => "Серебро",
                MetalType.Platinum => "Платина"
            };
        }

        /// <summary>
        /// Метод переводит тип Status в строку 
        /// </summary>
        public static string EnumName(Status status)
        {
            return status switch
            {
                Status.Redeemed => "Выкуплено",
                Status.Expired => "Срок действия истек",
                Status.Pledged => "Передано в залог"
            };
        }
    }
}
