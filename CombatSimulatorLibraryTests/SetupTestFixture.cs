using CombatSimulatorLibrary.Interfaces;
using CombatSimulatorLibrary.Items.Gear;
using CombatSimulatorLibrary.Persons;
using NUnit.Framework;

namespace CombatSimulatorLibraryTests
{
    [TestFixture]
    public class SetupTestFixture
    {
        protected IItem   Weapon { get; private set; }
        protected IItem   Armor  { get; private set; }
        protected IItem   Shield { get; private set; }
        protected IPerson Player { get; private set; }
        protected IPerson Enemy  { get; private set; }

        [OneTimeSetUp]
        public void SetupTests()
        {
            Weapon = new Weapon(100, "Long Sword", 2, 20);
            Armor  = new Armor(120, "Plate Armor", 10);
            Shield = new Shield(200, "Buckler", 10);
            Player = new Player("Kevin", 1, 10);
            Enemy  = new Enemy("Goblin", 2, 15);

            ((Player)Player).AddCoins(500);
            ((Player)Player).AddExperiencePoints(500);
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