using System;

namespace CombatSimulatorLibrary.Interfaces
{
    public interface ICommon
    {
        /// <summary>
        /// Converts all currency automagically.
        /// <params name="coinsInCopper" type="int">The coins in copper to be converted.</params>
        /// </summary>
        public static (int copper, int silver, int gold, int platinum) ConvertCurrency(int coinsInCopper)
        {
            var conversion = Convert(coinsInCopper);

            var copper = conversion.remainder;

            conversion = Convert(conversion.coin);
            var silver = conversion.remainder;

            conversion = Convert(conversion.coin);
            var gold = conversion.remainder;

            var platinum = conversion.coin;

            return (copper, silver, gold, platinum);
        }

        private static (int coin, int remainder) Convert(int coins)
        {
            var remainder = coins % 10;
            var coin      = (int) Math.Floor(coins / 10d);

            return (coin, remainder);
        }
    }
}