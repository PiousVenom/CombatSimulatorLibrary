using CombatSimulatorLibrary.Base;

namespace CombatSimulatorLibrary.Items.Gear
{
    public class Shield : Item
    {
        /// <summary>
        /// Creates a new Shield object
        /// </summary>
        /// <param name="cost" type="int">Amount the shield costs in gold pieces.</param>
        /// <param name="name" type="string">The name of the shield.</param>
        /// <param name="defense" type="int">How much defense this shield will provide.</param>
        public Shield(
                int cost,
                string name,
                int defense
            ) : base(cost, name)
        {
            Defense = defense;
        }

        #region Properties

        /// <summary>
        /// This is the defense provided by the shield.
        /// </summary>        
        public int Defense { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Displays the Shield Rating.
        /// </summary>
        /// <returns>A string to display an shield's defense rating.</returns>
        public string DisplayShield() => string.Concat("Shield Defense Rating: ", Defense);

        /// <summary>
        /// Sets the sell value of the shield.
        /// Formula: (15 * Cost) / 100
        /// </summary>
        public override void SetSellValue() => SellValue = (15 * CostInCopper) / 100;

        #endregion Methods
    }
}
