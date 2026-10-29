using Bibliotek;
using System;

namespace PDF6
{
    public class Type
    {
        /// <summary>
        /// Метод переводит строку в тип Condition
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
        /// Метод переводит строку в тип MetalType
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
        /// Метод переводит строку в тип Status
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
