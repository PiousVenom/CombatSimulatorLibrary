using CombatSimulatorLibrary.Items;
using System.Collections.Generic;

namespace CombatSimulatorLibrary.Base
{
    public abstract class Person
    {
        #region Properties

        /// <summary>
        /// Name of the person.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Level of the person.
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// Current hit points of the person.
        /// </summary>
        public int CurrentHitPoints { get; set; }
        /// <summary>
        /// Max hit points of the person.
        /// </summary>
        public int MaxHitPoints { get; set; }
        /// <summary>
        /// Inventory of the person.
        /// </summary>
        public List<Item> Inventory { get; set; }
        /// <summary>
        /// The weapon that is equipped to the person.
        /// </summary>
        public Weapon EquippedWeapon { get; set; }
        /// <summary>
        /// The armor that is equipped to the person.
        /// </summary>
        public Armor EquippedArmor { get; set; }
        #endregion Properties

        #region Methods

        /// <summary>
        /// Returns the amount of damage that a person deals.
        /// </summary>
        /// <returns type="int">Damage dealt.</returns>
        public int Attack()
        {
            return EquippedWeapon.SwingWeapon();
        }

        /// <summary>
        /// Returns the amount of damage that a person can defend against.
        /// </summary>
        /// <returns type="int">Amount of damage blocked.</returns>
        public int Defend()
        {
            return EquippedArmor.Defense;
        }

        /// <summary>
        /// Removes hit points after taking damage.
        /// </summary>
        /// <param name="hpLost" type="int">Amount of hit points to remove.</param>
        public void RemoveHitPoints(int hpLost)
        {
            CurrentHitPoints -= hpLost;
        }

        /// <summary>
        /// Resets a person hit points to their max.
        /// </summary>
        public void ResetHitPoints()
        {
            CurrentHitPoints = MaxHitPoints;
        }

        #endregion Methods
    }
}
