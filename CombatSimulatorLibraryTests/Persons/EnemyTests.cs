using CombatSimulatorLibrary.Items.Gear;
using CombatSimulatorLibrary.Persons;
using NUnit.Framework;

namespace CombatSimulatorLibraryTests.Persons
{
    public class EnemyTests : SetupTestFixture
    {
        [Test, Order(3)]
        [Category("Person Creation")]
        public void CanCreateEnemy()
        {
            Assert.IsInstanceOf(typeof(Enemy), Enemy);
            Assert.AreEqual("Goblin", Enemy.Name);
            Assert.AreEqual(2, Enemy.Level);
            Assert.AreEqual(15, Enemy.MaxHitPoints);
            Assert.AreEqual(15, Enemy.CurrentHitPoints);
            Assert.AreEqual(8, Enemy.ExperiencePointValue);
            Assert.GreaterOrEqual(Enemy.CopperPieceValue, 0);
            Assert.LessOrEqual(Enemy.CopperPieceValue, 200);
            Assert.AreEqual(3, Enemy.Inventory.Count);
            Assert.IsInstanceOf(typeof(Weapon), Enemy.EquippedWeapon);
            Assert.IsInstanceOf(typeof(Armor), Enemy.EquippedArmor);
            Assert.IsInstanceOf(typeof(Shield), Enemy.EquippedShield);
        }
    }
}
