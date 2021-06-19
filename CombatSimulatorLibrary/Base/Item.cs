using CombatSimulatorLibrary.CommonClasses;
using CombatSimulatorLibrary.Interfaces;

namespace CombatSimulatorLibrary.Base
{
    public abstract class Item : IItem
    {
        protected Item(
                int    cost,
                string name
            )
        {
            CostInCopper = cost;
            Name         = name;
        }

        #region Properties

        /// <summary>
        /// Name of the item.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Items cost in gold pieces.
        /// </summary>
        protected int CostInCopper { get; }

        /// <summary>
        /// How much the item will sell for to a vendor.
        /// </summary>
        public int SellValue { get; protected set; }

        /// <summary>
        /// Whether or not an item is equipped to the person.
        /// </summary>
        public bool IsEquipped { get; set; }

        /// <summary>
        /// Amount of gold item is worth
        /// </summary>
        public int Gold { get; private set; }

        /// <summary>
        /// Amount of platinum item is worth
        /// </summary>
        public int Platinum { get; private set; }

        /// <summary>
        /// Amount of silver item is worth
        /// </summary>
        public int Silver { get; private set; }

        /// <summary>
        /// Amount of copper item is worth
        /// </summary>
        public int Copper { get; private set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Sets the default sell value for an item.
        /// Formula: (10 * Cost) / 100
        /// </summary>
        public virtual void SetSellValue() => SellValue = 10 * CostInCopper / 100;

        public void ConvertCurrency()
        {
            var coins = CommonMethods.ConvertCurrency(CostInCopper);

            Copper   = coins.copper;
            Silver   = coins.silver;
            Gold     = coins.gold;
            Platinum = coins.platinum;
        }

        #endregion Methods
    }
}