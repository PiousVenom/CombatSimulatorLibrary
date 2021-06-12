namespace CombatSimulatorLibrary.Interfaces
{
    public interface ICoin
    {
        void ConvertCurrency(ref ICoin nextCoin);

        int Amount { get; set; }

        void Add(int amount);

        void Add(int amount, ref ICoin nextCoin);

        void Remove(int amount);
    }
}