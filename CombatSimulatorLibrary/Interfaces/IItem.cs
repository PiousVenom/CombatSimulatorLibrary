using CombatSimulatorLibrary.CommonClasses;

namespace CombatSimulatorLibrary.Interfaces
{
    public interface IItem
    {
        #region Methods

        /// <summary>
        /// Sets the default sell value for an item.
        /// Formula: (10 * Cost) / 100
        /// </summary>
        public void SetSellValue() => SellValue = 10 * CostInCopper / 100;

        public void ConvertCurrency()
        {
            var coins = CommonMethods.ConvertCurrency(CostInCopper);

            Copper   = coins.copper;
            Silver   = coins.silver;
            Gold     = coins.gold;
            Platinum = coins.platinum;
        }

        #endregion Methods

        #region Properties

        int    CostInCopper { get; }
        string Name         { get; }
        int    SellValue    { get; set; }
        bool   IsEquipped   { get; set; }
        int    Gold         { get; set; }
        int    Platinum     { get; set; }
        int    Silver       { get; set; }
        int    Copper       { get; set; }

        #endregion Properties
    }
}