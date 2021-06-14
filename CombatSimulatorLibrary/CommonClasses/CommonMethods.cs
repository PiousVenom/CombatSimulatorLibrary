using System;

namespace CombatSimulatorLibrary.CommonClasses
{
    public class CommonMethods
    {
        public int CoinsInCopper;

        public CommonMethods(int coinsInCopper) => CoinsInCopper = coinsInCopper;

        /// <summary>
        /// Converts all currency automagically.
        /// </summary>
        public Tuple<int, int, int, int> ConvertCurrency()
        {
            var conversion = Convert(CoinsInCopper);

            var copper = conversion.Item2;

            conversion = Convert(conversion.Item1);
            var silver = conversion.Item2;

            conversion = Convert(conversion.Item1);
            var gold = conversion.Item2;

            var platinum = conversion.Item1;

            return new Tuple<int, int, int, int>(copper, silver, gold, platinum);
        }

        private static Tuple<int, int> Convert(int coins)
        {
            var remainder = coins % 10;
            var coin = (int)Math.Floor(coins / 10d);

            return new Tuple<int, int>(coin, remainder);
        }
    }
}
