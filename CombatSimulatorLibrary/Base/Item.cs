using CombatSimulatorLibrary.Interfaces;

namespace CombatSimulatorLibrary.Base
{
    public abstract class Item: IItem
    {
        #region Properties

        /// <summary>
        /// Name of the item.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Items cost in gold pieces.
        /// </summary>
        public int Cost { get; set; }
        /// <summary>
        /// How much the item will sell for to a vendor.
        /// </summary>
        public int SellValue { get; set; }
        /// <summary>
        /// Whether or not an item is equipped to the person.
        /// </summary>
        public bool IsEquipped { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Sets the default sell value for an item.
        /// Formula: (10 * Cost) / 100
        /// </summary>
        public virtual void SetSellValue() => SellValue = (10 * Cost) / 100;

        #endregion Methods
    }
}