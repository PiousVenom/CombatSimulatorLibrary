using System.Collections.Generic;
using CombatSimulatorLibrary.Interfaces;
using CombatSimulatorLibrary.Items.Gear;

namespace CombatSimulatorLibrary.Base
{
    public abstract class Person : IPerson
    {
        protected Person(
                string name, 
                int level, 
                int maxHitPoints
            )
        {
            Name = name;
            Level = level;
            MaxHitPoints = maxHitPoints;
            Inventory = new List<IItem>();
        }

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
        public List<IItem> Inventory { get; set; }
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
        public void RemoveItemFromInventory(Item itemToRemove)
        {
            if (EquippedShield == itemToRemove)
            {
                UnequipShield(itemToRemove as Shield);
            }

            if (EquippedArmor == itemToRemove)
            {
                UnequipArmor(itemToRemove as Armor);
            }

            if (EquippedWeapon == itemToRemove)
            {
                UnequipWeapon(itemToRemove as Weapon);
            }

            Inventory.Remove((Item) itemToRemove);
        }

        /// <summary>
        /// Weapon to equip to the person.
        /// </summary>
        /// <param name="weaponToEquip" type="Weapon">Weapon to equip to the person.</param>
        public void EquipWeapon(Weapon weaponToEquip)
        {
            EquippedWeapon = weaponToEquip;
            weaponToEquip.IsEquipped = true;
        }

        /// <summary>
        /// Unequip weapon from the person.
        /// </summary>
        /// <param name="weaponToUnequip" type="Weapon">Weapon to unequip from the person.</param>
        public void UnequipWeapon(Weapon weaponToUnequip)
        {
            weaponToUnequip.IsEquipped = false;
            EquippedWeapon = null;
        }

        /// <summary>
        /// Equips armor to the person.
        /// </summary>
        /// <param name="armorToEquip" type="Armor">Armor to equip to the person.</param>
        public void EquipArmor(Armor armorToEquip)
        {
            EquippedArmor = armorToEquip;
            armorToEquip.IsEquipped = true;
        }

        /// <summary>
        /// Unequip armor from the person.
        /// </summary>
        /// <param name="armorToUnequip" type="Armor">Armor to unequip from the person.</param>
        public void UnequipArmor(Armor armorToUnequip)
        {
            armorToUnequip.IsEquipped = false;
            EquippedArmor = null;
        }

        /// <summary>
        /// Equips shield to the person
        /// </summary>
        /// <param name="shieldToEquip" type="Shield">Shield to equip to the person.</param>
        public void EquipShield(Shield shieldToEquip)
        {
            EquippedShield = shieldToEquip;
            shieldToEquip.IsEquipped = true;
        }

        /// <summary>
        /// Unequip shield from the person
        /// </summary>
        /// <param name="shieldToUnequip" type="Shield">Shield to unequip from the person.</param>
        public void UnequipShield(Shield shieldToUnequip)
        {
            shieldToUnequip.IsEquipped = false;
            EquippedShield = null;
        }
        
        #endregion Methods
    }
}