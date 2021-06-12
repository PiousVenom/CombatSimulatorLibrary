using System;
using System.Collections.Generic;
using CombatSimulatorLibrary.Interfaces;
using CombatSimulatorLibrary.Items.Currency;
using CombatSimulatorLibrary.Items.Gear;

namespace CombatSimulatorLibrary.Base
{
    public abstract class Person : IPerson
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
        /// Current experience points for the player
        /// </summary>
        public int CurrentExperiencePoints { get; set; }
        /// <summary>
        /// Current amount of gold coins a person has
        /// </summary>
        public Gold Gold { get; set; }
        /// <summary>
        /// Current amount of platinum coins a person has
        /// </summary>
        public Platinum Platinum { get; set; }
        /// <summary>
        /// Current amount of silver coins a person has
        /// </summary>
        public Silver Silver { get; set; }
        /// <summary>
        /// Current amount of copper coins a person has
        /// </summary>
        public Copper Copper { get; set; }
        /// <summary>
        /// Inventory of the person.
        /// </summary>
        public List<Item> Inventory { get; set; }
        /// <summary>
        /// The weapon currently equipped to the person.
        /// </summary>
        public Weapon EquippedWeapon { get; set; }
        /// <summary>
        /// The armor currently equipped to the person.
        /// </summary>
        public Armor EquippedArmor { get; set; }
        /// <summary>
        /// The shield currently equipped to the person
        /// </summary>
        public Shield EquippedShield { get; set; }

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
        public int Defend() => EquippedArmor.Defense + EquippedShield.Defense;

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
        /// <param name="itemToAdd" type="Item">Item to be added to the inventory.</param>
        public void AddItemToInventory(Item itemToAdd) => Inventory.Add(itemToAdd);

        /// <summary>
        /// Removes an item from the person's inventory.
        /// </summary>
        /// <param name="itemToRemove" type="Item">Item to be removed from the inventory.</param>
        public void RemoveItemFromInventory(Item itemToRemove) => Inventory.Remove(itemToRemove);

        /// <summary>
        /// Weapon to equip to the person.
        /// </summary>
        /// <param name="weaponToEquip" type="Weapon">Weapon to equip to the person.</param>
        public void EquipWeapon(Weapon weaponToEquip) => EquippedWeapon = weaponToEquip;

        /// <summary>
        /// Equips armor to the person.
        /// </summary>
        /// <param name="armorToEquip" type="Armor">Armor to equip to the person.</param>
        public void EquipArmor(Armor armorToEquip) => EquippedArmor = armorToEquip;

        /// <summary>
        /// Equips shield to the person
        /// </summary>
        /// <param name="shieldToEquip" type="Shield">Shield to equip to the person.</param>
        public void EquipShield(Shield shieldToEquip) => EquippedShield = shieldToEquip;

        public virtual void ConvertCurrency()
        {

        }

        #endregion Methods
    }
}