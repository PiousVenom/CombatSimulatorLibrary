using CombatSimulatorLibrary.Interfaces;

namespace CombatSimulatorLibrary.Items.Gear
{
    public class Shield : IItem
    {
        /// <summary>
        /// Creates a new Shield object
        /// </summary>
        /// <param name="cost" type="int">Amount the shield costs in gold pieces.</param>
        /// <param name="name" type="string">The name of the shield.</param>
        /// <param name="defense" type="int">How much defense this shield will provide.</param>
        private Shield(
                int    cost,
                string name,
                int    defense
            )
        {
            Name         = name;
            CostInCopper = cost;
            Defense      = defense;
        }

        public static Shield CreateInstance(int cost, string name, int defense) => new Shield(cost, name, defense);

        #region Properties

        /// <summary>
        /// This is the defense provided by the shield.
        /// </summary>        
        public int Defense { get; }

        public int    CostInCopper { get; }
        public string Name         { get; }
        public int    SellValue    { get; set; }
        public bool   IsEquipped   { get; set; }
        public int    Gold         { get; set; }
        public int    Platinum     { get; set; }
        public int    Silver       { get; set; }
        public int    Copper       { get; set; }

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
        public void SetSellValue() => SellValue = 15 * CostInCopper / 100;

        #endregion Methods
    }
}