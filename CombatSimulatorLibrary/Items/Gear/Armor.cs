using CombatSimulatorLibrary.Base;

namespace CombatSimulatorLibrary.Items.Gear
{
    public class Armor : Item
    {
        #region Properties

        /// <summary>
        /// This is the defense provided by the armor.
        /// </summary>        
        public int Defense { get; }

        #endregion Properties

        /// <summary>
        /// Creates a new Armor object
        /// </summary>
        /// <param name="cost" type="int">Amount the armor costs in gold pieces.</param>
        /// <param name="name" type="string">The name of the armor.</param>
        /// <param name="defense" type="int">How much defense this armor will provide.</param>
        public Armor(
                int    cost,
                string name,
                int    defense
            )
            : base(cost, name)
        {
            Defense = defense;
        }

        #region Methods

        /// <summary>
        /// Displays the Armor Rating.
        /// </summary>
        /// <returns>A string to display an armor's defense rating.</returns>
        public string DisplayArmor() => string.Concat("Armor Defense Rating: ", Defense);

        /// <summary>
        /// Sets the sell value of the armor.
        /// </summary>
        public override void SetSellValue() => SellValue = 35 * CostInCopper / 100;

        #endregion Methods
    }
}