using CombatSimulatorLibrary.Interfaces;

namespace CombatSimulatorLibrary.Items.Gear
{
    public class Armor : IItem
    {
        /// <summary>
        /// Creates a new Armor object
        /// </summary>
        /// <param name="cost" type="int">Amount the armor costs in gold pieces.</param>
        /// <param name="name" type="string">The name of the armor.</param>
        /// <param name="defense" type="int">How much defense this armor will provide.</param>
        private Armor(
                int    cost,
                string name,
                int    defense
            )
        {
            Name         = name;
            CostInCopper = cost;
            Defense      = defense;
        }

        public static Armor CreateInstance(int cost, string name, int defense) => new Armor(cost, name, defense);

        #region Properties

        public int    CostInCopper { get; }
        public string Name         { get; }
        public int    SellValue    { get; set; }
        public bool   IsEquipped   { get; set; }
        public int    Gold         { get; set; }
        public int    Platinum     { get; set; }
        public int    Silver       { get; set; }
        public int    Copper       { get; set; }

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
        public string DisplayArmor() => string.Concat("Armor Defense Rating: ", Defense);

        /// <summary>
        /// Sets the sell value of the armor.
        /// </summary>
        public void SetSellValue() => SellValue = 35 * CostInCopper / 100;

        #endregion Methods
    }
}