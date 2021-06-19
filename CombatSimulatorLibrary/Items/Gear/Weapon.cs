using System.Security.Cryptography;
using CombatSimulatorLibrary.Interfaces;

namespace CombatSimulatorLibrary.Items.Gear
{
    public class Weapon : IItem
    {
        /// <summary>
        /// Creates a new Weapon object
        /// </summary>
        /// <param name="cost" type="int">Amount the weapon costs in gold pieces.</param>
        /// <param name="name" type="string">The name of the weapon.</param>
        /// <param name="minDamage" type="int">Minimum damage the weapon can do.</param>
        /// <param name="maxDamage" type="int">Maximum damage the weapon can do.</param>
        private Weapon(
                int    cost,
                string name,
                int    minDamage,
                int    maxDamage
            )
        {
            Name         = name;
            CostInCopper = cost;
            MinDamage    = minDamage;
            MaxDamage    = maxDamage;
        }

        public static Weapon CreateInstance(int cost, string name, int minDamage, int maxDamage) =>
            new Weapon(cost, name, minDamage, maxDamage);

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
        /// This is the minimum damage that a weapon can do.
        /// </summary>
        private int MinDamage { get; }

        /// <summary>
        /// This is the maximum damage that a weapon can do.
        /// </summary>
        private int MaxDamage { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Swings the weapon to do damage.
        /// </summary>
        /// <returns>Returns the amount of damage dealt, random between Min and Max properties.</returns>
        public int SwingWeapon()
        {
            var random = RandomNumberGenerator.GetInt32(MinDamage, MaxDamage);

            return random;
        }

        /// <summary>
        /// Displays the damage range that a weapon can do.
        /// </summary>
        /// <returns>A string to display weapons damage range.</returns>
        public string DisplayDamage() => MinDamage + " - " + MaxDamage;

        #endregion Methods
    }
}