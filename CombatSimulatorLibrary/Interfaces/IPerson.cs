using System.Collections.Generic;

namespace CombatSimulatorLibrary.Interfaces
{
    public interface IPerson
    {
        #region Properties

        string      Name             { get; }
        int         Level            { get; }
        int         CurrentHitPoints { get; }
        int         MaxHitPoints     { get; }
        int         CoinsInCopper    { get; }
        int         Gold             { get; set; }
        int         Platinum         { get; set; }
        int         Silver           { get; set; }
        int         Copper           { get; set; }
        List<IGear> Inventory        { get; }
        IGear       EquippedWeapon   { get; }
        IGear       EquippedArmor    { get; }
        IGear       EquippedShield   { get; }

        #endregion Properties

        #region Methods

        int Attack();

        int? Defend();

        void RemoveHitPoints(int hpLost);

        void ResetHitPoints();

        void AddItemToInventory(IGear gearToAdd);

        void RemoveItemFromInventory(IGear gearToRemove);

        void EquipWeapon(IGear weaponToEquip);

        void EquipArmor(IGear armorToEquip);

        void EquipShield(IGear shieldToEquip);

        #endregion Methods
    }
}