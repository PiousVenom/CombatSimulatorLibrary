using CombatSimulatorLibrary.CommonClasses;
using CombatSimulatorLibrary.Interfaces;

namespace CombatSimulatorLibrary.Base
{
    public abstract class Item: IItem
    {
        protected Item(
                int cost,
                string name
            )
        {
            CostInCopper = cost;
            Name = name;
        }

        #region Properties

        /// <summary>
        /// Name of the item.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Items cost in gold pieces.
        /// </summary>
        public int CostInCopper { get; set; }
        /// <summary>
        /// How much the item will sell for to a vendor.
        /// </summary>
        public int SellValue { get; set; }
        /// <summary>
        /// Whether or not an item is equipped to the person.
        /// </summary>
        public bool IsEquipped { get; set; }
        /// <summary>
        /// Amount of gold item is worth
        /// </summary>
        public int Gold { get; set; }
        /// <summary>
        /// Amount of platinum item is worth
        /// </summary>
        public int Platinum { get; set; }
        /// <summary>
        /// Amount of silver item is worth
        /// </summary>
        public int Silver { get; set; }
        /// <summary>
        /// Amount of copper item is worth
        /// </summary>
        public int Copper { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Sets the default sell value for an item.
        /// Formula: (10 * Cost) / 100
        /// </summary>
        public virtual void SetSellValue() => SellValue = (10 * CostInCopper) / 100;

        public virtual void ConvertCurrency()
        {
            var common = new CommonMethods(CostInCopper);
            var coins = common.ConvertCurrency();

            Copper = coins.Item1;
            Silver = coins.Item2;
            Gold = coins.Item3;
            Platinum = coins.Item4;
        }

        #endregion Methods
    }
}