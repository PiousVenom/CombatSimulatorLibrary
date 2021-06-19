using System.Collections.Generic;
using CombatSimulatorLibrary.Items.Gear;

namespace CombatSimulatorLibrary.Interfaces
{
    public interface IPerson
    {
        #region Properties

        string      Name             { get; }
        int         Level            { get; }
        int         CurrentHitPoints { get; }
        int         MaxHitPoints     { get; }
        int         Gold             { get; }
        int         Platinum         { get; }
        int         Silver           { get; }
        int         Copper           { get; }
        List<IItem> Inventory        { get; }
        Weapon      EquippedWeapon   { get; }
        Armor       EquippedArmor    { get; }
        Shield      EquippedShield   { get; }

        #endregion Properties

        #region Methods

        int Attack();

        int Defend();

        void RemoveHitPoints(int hpLost);

        void ResetHitPoints();

        void AddItemToInventory(IItem itemToAdd);

        void RemoveItemFromInventory(IItem itemToRemove);

        void EquipWeapon(IItem weaponToEquip);

        void EquipArmor(IItem armorToEquip);

        void EquipShield(IItem shieldToEquip);

        #endregion Methods
    }
}