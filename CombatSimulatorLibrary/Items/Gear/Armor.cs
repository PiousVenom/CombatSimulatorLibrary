using CombatSimulatorLibrary.Base;

namespace CombatSimulatorLibrary.Items.Gear
{
    public class Armor : Item
    {
        /// <summary>
        /// Creates a new Armor object
        /// </summary>
        /// <param name="defense" type="int">How much defense this armor will provide.</param>
        public Armor(int defense) => Defense = defense;

        #region Properties

        /// <summary>
        /// This is the defense provided by the armor.
        /// </summary>        
        public int Defense { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Displays the Armor Rating.
        /// </summary>
        /// <returns>A string to display an armor's defense rating.</returns>
        public string DisplayArmor() => "Armor Defense Rating: " + Defense;

        /// <summary>
        /// Sets the sell value of the armor.
        /// </summary>
        public override void SetSellValue() => SellValue = (35 * Cost) / 100;

        #endregion Methods
    }
}
