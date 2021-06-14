using System.Collections.Generic;
using CombatSimulatorLibrary.Base;
using CombatSimulatorLibrary.Items.Gear;

namespace CombatSimulatorLibrary.Interfaces
{
    public interface IPerson
    {
        #region Properties

        string Name { get; set; }
        int Level { get; set; }
        int CurrentHitPoints { get; set; }
        int MaxHitPoints { get; set; }
        int Gold { get; set; }
        int Platinum { get; set; }
        int Silver { get; set; }
        int Copper { get; set; }
        List<IItem> Inventory { get; set; }
        Weapon EquippedWeapon { get; set; }
        Armor EquippedArmor { get; set; }
        Shield EquippedShield { get; set; }

        #endregion Properties

        #region Methods

        int Attack();

        int Defend();

        void RemoveHitPoints(int hpLost);

        void ResetHitPoints();

        void AddItemToInventory(Item itemToAdd);

        void RemoveItemFromInventory(Item itemToRemove);

        void EquipWeapon(Weapon weaponToEquip);

        void EquipArmor(Armor armorToEquip);

        void EquipShield(Shield shieldToEquip);

        #endregion Methods
    }
}