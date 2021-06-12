using System;
using CombatSimulatorLibrary.Interfaces;

namespace CombatSimulatorLibrary.Base
{
    public class Coin : ICoin
    {
        public int Amount { get; set; }

        public virtual void ConvertCurrency(ref ICoin nextCoin)
        {
            if (Amount <= 10) return;

            var (addToNext, setToCurrent) = Convert();

            Amount = setToCurrent;
            nextCoin.Add(addToNext);
        }

        public virtual void Add(int amount, ref ICoin nextCoin)
        {
            Amount += amount;
            ConvertCurrency(ref nextCoin);
        }

        public virtual void Add(int amount)
        {
            Amount += amount;
        }

        public virtual void Remove(int amount)
        {
            //TODO: Fix in case the coin goes negative!!!
            Amount -= amount;
        }

        internal Tuple<int, int> Convert()
        {
            var toConvert = Math.Floor(Amount / 10d);
            var remainder = Amount % 10;

            return new Tuple<int, int>((int)toConvert, remainder);
        }
    }
}