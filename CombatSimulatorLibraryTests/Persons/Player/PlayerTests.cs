using CombatSimulatorLibrary.Interfaces;
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
            Assert.AreEqual(Player.EquippedWeapon.Purpose, Purpose.Weapon);
            Assert.AreEqual(Player.EquippedArmor.Purpose,  Purpose.Armor);
            Assert.AreEqual(Player.EquippedShield.Purpose, Purpose.Shield);
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
        public void PersonCanRemoveGear()
        {
            Player.RemoveItemFromInventory(Shield);
            Player.RemoveItemFromInventory(Armor);
            Player.RemoveItemFromInventory(Weapon);

            Assert.AreEqual(0, Player.Inventory.Count);
            Assert.IsNull(Player.EquippedShield);
            Assert.IsNull(Player.EquippedArmor);
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
            var (copper, silver, gold, platinum)                           = ICommon.ConvertCurrency(Player.CoinsInCopper);
            Player.Copper                                                  = copper;
            Player.Silver                                                  = silver;
            Player.Gold                                                    = gold;
            Player.Platinum                                                = platinum;
            
            Assert.AreEqual(0, Player.Copper);
            Assert.AreEqual(0, Player.Silver);
            Assert.AreEqual(5, Player.Gold);
            Assert.AreEqual(0, Player.Platinum);
        }
    }
}