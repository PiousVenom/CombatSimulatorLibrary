using CombatSimulatorLibrary.Items.Gear;
using NUnit.Framework;

namespace CombatSimulatorLibraryTests.Persons.Player
{
    public class PlayerTests : SetupTestFixture
    {
        [Test]
        [Order(2)]
        [Category("Person Creation")]
        public void CanCreatePlayer()
        {
            Assert.IsInstanceOf(typeof(CombatSimulatorLibrary.Persons.Player), Player);
            Assert.AreEqual("Kevin", Player.Name);
            Assert.AreEqual(1,       Player.Level);
            Assert.AreEqual(10,      Player.MaxHitPoints);
            Assert.AreEqual(10,      Player.CurrentHitPoints);
            Assert.AreEqual(500,     ((CombatSimulatorLibrary.Persons.Player) Player).CurrentExperiencePoints);
            Assert.AreEqual(500,     ((CombatSimulatorLibrary.Persons.Player) Player).CoinsInCopper);
            Assert.AreEqual(500,     ((CombatSimulatorLibrary.Persons.Player) Player).CurrentExperiencePoints);
            Assert.AreEqual(3,       Player.Inventory.Count);
            Assert.IsInstanceOf(typeof(Weapon), Player.EquippedWeapon);
            Assert.IsInstanceOf(typeof(Armor),  Player.EquippedArmor);
            Assert.IsInstanceOf(typeof(Shield), Player.EquippedShield);
        }

        [Test]
        [Order(4)]
        [Category("Person Specific")]
        public void CanUpdatePlayerTest()
        {
            ((CombatSimulatorLibrary.Persons.Player) Player).AddExperiencePoints(500);
            Player.RemoveHitPoints(3);

            var attack = Player.Attack();
            var defend = Player.Defend();

            Assert.AreEqual(7,    Player.CurrentHitPoints);
            Assert.AreEqual(1000, ((CombatSimulatorLibrary.Persons.Player) Player).CurrentExperiencePoints);
            Assert.GreaterOrEqual(attack, 2);
            Assert.LessOrEqual(attack, 20);
            Assert.AreEqual(20, defend);
        }

        [Test]
        [Order(6)]
        [Category("Person Specific")]
        public void PersonCanRemoveArmor()
        {
            Player.RemoveItemFromInventory(Armor);

            Assert.AreEqual(1, Player.Inventory.Count);
            Assert.IsNull(Player.EquippedArmor);
        }

        [Test]
        [Order(8)]
        [Category("Person Specific")]
        public void PersonCanRemoveCoins()
        {
            ((CombatSimulatorLibrary.Persons.Player) Player).RemoveCoins(100);

            Assert.AreEqual(400, ((CombatSimulatorLibrary.Persons.Player) Player).CoinsInCopper);
        }

        [Test]
        [Order(10)]
        [Category("Person Specific")]
        public void PersonCanRemoveMoreCoinsThanAvailable()
        {
            var test = ((CombatSimulatorLibrary.Persons.Player) Player).RemoveCoins(100000);

            Assert.False(test);
        }

        [Test]
        [Order(5)]
        [Category("Person Specific")]
        public void PersonCanRemoveShield()
        {
            Player.RemoveItemFromInventory(Shield);

            Assert.AreEqual(2, Player.Inventory.Count);
            Assert.IsNull(Player.EquippedShield);
        }

        [Test]
        [Order(7)]
        [Category("Person Specific")]
        public void PersonCanRemoveWeapon()
        {
            Player.RemoveItemFromInventory(Weapon);

            Assert.AreEqual(0, Player.Inventory.Count);
            Assert.IsNull(Player.EquippedWeapon);
        }

        [Test]
        [Order(11)]
        [Category("Person Specific")]
        public void PersonCanResetHitPoints()
        {
            Player.ResetHitPoints();

            Assert.AreEqual(Player.CurrentHitPoints, Player.MaxHitPoints);
        }

        [Test]
        [Order(9)]
        [Category("Person Specific")]
        public void PersonCurrencyConversionTest()
        {
            ((CombatSimulatorLibrary.Persons.Player) Player).CoinsInCopper = 500;
            ((CombatSimulatorLibrary.Persons.Player) Player).ConvertCurrency();
            Assert.AreEqual(0, Player.Copper);
            Assert.AreEqual(0, Player.Silver);
            Assert.AreEqual(5, Player.Gold);
            Assert.AreEqual(0, Player.Platinum);
        }
    }
}