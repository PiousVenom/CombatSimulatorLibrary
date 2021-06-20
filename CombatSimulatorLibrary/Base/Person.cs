using System.Collections.Generic;
using CombatSimulatorLibrary.Interfaces;

namespace CombatSimulatorLibrary.Base
{
    public abstract class Person : IPerson
    {
        protected Person(
                string name,
                int    level,
                int    maxHitPoints
            )
        {
            Name         = name;
            Level        = level;
            MaxHitPoints = maxHitPoints;
            Inventory    = new List<IGear>();
        }

        #region Properties

        /// <summary>
        /// Name of the person.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Level of the person.
        /// </summary>
        public int Level { get; }

        /// <summary>
        /// Current hit points of the person.
        /// </summary>
        public int CurrentHitPoints { get; protected set; }

        /// <summary>
        /// Max hit points of the person.
        /// </summary>
        public int MaxHitPoints { get; }

        public int CoinsInCopper { get; set; }

        /// <summary>
        /// Current amount of gold coins a person has
        /// </summary>
        public int Gold { get; set; }

        /// <summary>
        /// Current amount of platinum coins a person has
        /// </summary>
        public int Platinum { get; set; }

        /// <summary>
        /// Current amount of silver coins a person has
        /// </summary>
        public int Silver { get; set; }

        /// <summary>
        /// Current amount of copper coins a person has
        /// </summary>
        public int Copper { get; set; }

        /// <summary>
        /// Inventory of the person.
        /// </summary>
        public List<IGear> Inventory { get; }

        /// <summary>
        /// The weapon currently equipped to the person.
        /// </summary>
        public IGear EquippedWeapon { get; private set; }

        /// <summary>
        /// The armor currently equipped to the person.
        /// </summary>
        public IGear EquippedArmor { get; private set; }

        /// <summary>
        /// The shield currently equipped to the person
        /// </summary>
        public IGear EquippedShield { get; private set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Returns the amount of damage that a person deals.
        /// </summary>
        /// <returns type="int">Damage dealt.</returns>
        public int Attack() => EquippedWeapon.SwingWeapon();

        /// <summary>
        /// Returns the amount of damage that a person can defend against.
        /// </summary>
        /// <returns type="int">Amount of damage blocked.</returns>
        public int? Defend() => EquippedArmor.Defense + EquippedShield.Defense;

        /// <summary>
        /// Removes hit points after taking damage.
        /// </summary>
        /// <param name="hpLost" type="int">Amount of hit points to remove.</param>
        public void RemoveHitPoints(int hpLost) => CurrentHitPoints -= hpLost;

        /// <summary>
        /// Resets a person hit points to their max.
        /// </summary>
        public void ResetHitPoints() => CurrentHitPoints = MaxHitPoints;

        /// <summary>
        /// Adds an item from the person's inventory.
        /// </summary>
        /// <param name="gearToAdd" type="Item">Item to be added to the inventory.</param>
        public void AddItemToInventory(IGear gearToAdd) => Inventory.Add(gearToAdd);

        /// <summary>
        /// Removes an item from the person's inventory.
        /// </summary>
        /// <param name="gearToRemove" type="Item">Item to be removed from the inventory.</param>
        public void RemoveItemFromInventory(IGear gearToRemove)
        {
            if(EquippedShield == gearToRemove)
            {
                UnequipShield(gearToRemove);
            }

            if(EquippedArmor == gearToRemove)
            {
                UnequipArmor(gearToRemove);
            }

            if(EquippedWeapon == gearToRemove)
            {
                UnequipWeapon(gearToRemove);
            }

            Inventory.Remove(gearToRemove);
        }

        /// <summary>
        /// Weapon to equip to the person.
        /// </summary>
        /// <param name="weaponToEquip" type="Weapon">Weapon to equip to the person.</param>
        public void EquipWeapon(IGear weaponToEquip)
        {
            EquippedWeapon           = weaponToEquip;
            weaponToEquip.IsEquipped = true;
        }

        /// <summary>
        /// Unequip weapon from the person.
        /// </summary>
        /// <param name="weaponToUnequip" type="Weapon">Weapon to unequip from the person.</param>
        private void UnequipWeapon(IGear weaponToUnequip)
        {
            weaponToUnequip.IsEquipped = false;
            EquippedWeapon             = null;
        }

        /// <summary>
        /// Equips armor to the person.
        /// </summary>
        /// <param name="armorToEquip" type="Armor">Armor to equip to the person.</param>
        public void EquipArmor(IGear armorToEquip)
        {
            EquippedArmor           = armorToEquip;
            armorToEquip.IsEquipped = true;
        }

        /// <summary>
        /// Unequip armor from the person.
        /// </summary>
        /// <param name="armorToUnequip" type="IItem">Armor to unequip from the person.</param>
        private void UnequipArmor(IGear armorToUnequip)
        {
            armorToUnequip.IsEquipped = false;
            EquippedArmor             = null;
        }

        /// <summary>
        /// Equips shield to the person
        /// </summary>
        /// <param name="shieldToEquip" type="IItem">Shield to equip to the person.</param>
        public void EquipShield(IGear shieldToEquip)
        {
            EquippedShield           = shieldToEquip;
            shieldToEquip.IsEquipped = true;
        }

        /// <summary>
        /// Unequip shield from the person
        /// </summary>
        /// <param name="shieldToUnequip" type="IItem">Shield to unequip from the person.</param>
        private void UnequipShield(IGear shieldToUnequip)
        {
            shieldToUnequip.IsEquipped = false;
            EquippedShield             = null;
        }

        #endregion Methods
    }
}