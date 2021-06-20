using CombatSimulatorLibrary.Interfaces;
using CombatSimulatorLibrary.Items.Gear;
using CombatSimulatorLibrary.Persons;
using NUnit.Framework;

namespace CombatSimulatorLibraryTests
{
    public class SetupTestFixture
    {
        protected IGear   Weapon      { get; private set; }
        protected IGear   BrokeWeapon { get; private set; }
        protected IGear   NoPurpose   { get; private set; }
        protected IGear   Armor       { get; private set; }
        protected IGear   Shield      { get; private set; }
        protected IPerson Player      { get; private set; }
        protected IPerson Enemy       { get; private set; }

        [OneTimeSetUp]
        public void SetupTests()
        {
            Weapon      = new Gear(200, "Long Sword",   Purpose.Weapon, 2, 20);
            BrokeWeapon = new Gear(200, "Broke Weapon", Purpose.Weapon);
            NoPurpose   = new Gear(200, "Broke Weapon", Purpose.Undefined);
            Armor       = new Gear(200, "Plate Armor",  Purpose.Armor,  10);
            Shield      = new Gear(200, "Buckler",      Purpose.Shield, 10);
            Player      = new Player("Kevin", 1, 10);
            Enemy       = new Enemy("Goblin", 2, 15);

            ((Player) Player).AddCoins(500);
            ((Player) Player).AddExperiencePoints(500);
            Player.AddItemToInventory(Shield);
            Player.AddItemToInventory(Weapon);
            Player.AddItemToInventory(Armor);

            Player.EquipShield(Shield);
            Player.EquipArmor(Armor);
            Player.EquipWeapon(Weapon);

            Enemy.AddItemToInventory(Shield);
            Enemy.AddItemToInventory(Weapon);
            Enemy.AddItemToInventory(Armor);

            Enemy.EquipShield(Shield);
            Enemy.EquipArmor(Armor);
            Enemy.EquipWeapon(Weapon);
        }
    }
}