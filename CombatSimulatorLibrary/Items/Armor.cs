using CombatSimulatorLibrary.Base;

namespace CombatSimulatorLibrary.Items
{
    public class Armor : Item
    {
        /// <summary>
        /// Creates a new Armor object
        /// </summary>
        /// <param name="defense" type="int">How much defense this armor will provide.</param>
        public Armor(int defense)
        {
            Defense = defense;
        }

        /// <summary>
        /// This is the defense provided by the armor.
        /// </summary>
        #region Properties
        public int Defense { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Sets the sell value of the armor.
        /// </summary>
        public override void SetSellValue()
        {
            var tempNumber = 35 * Cost;
            SellValue = tempNumber / 100;
        }

        #endregion Methods
    }
}
