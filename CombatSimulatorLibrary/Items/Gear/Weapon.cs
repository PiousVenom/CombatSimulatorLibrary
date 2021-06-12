using System;
using CombatSimulatorLibrary.Base;

namespace CombatSimulatorLibrary.Items.Gear
{
    public class Weapon : Item
    {
        /// <summary>
        /// Creates a new Weapon object
        /// </summary>
        /// <param name="cost" type="int">Amount the weapon costs in gold pieces.</param>
        /// <param name="minDamage" type="int">Minimum damage the weapon can do.</param>
        /// <param name="maxDamage" type="int">Maximum damage the weapon can do.</param>
        /// <param name="name" type="string">The name of the weapon.</param>
        public Weapon(int cost,
                      int minDamage,
                      int maxDamage,
                      string name)
        {
            MinDamage = minDamage;
            MaxDamage = maxDamage;
            Name = name;
            Cost = cost;
        }

        #region Properties

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
        public int SwingWeapon() => new Random().Next(MinDamage, MaxDamage);

        /// <summary>
        /// Displays the damage range that a weapon can do.
        /// </summary>
        /// <returns>A string to display weapons damage range.</returns>
        public string DisplayDamage() => MinDamage + " - " + MaxDamage;

        #endregion Methods
    }
}
