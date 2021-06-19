using CombatSimulatorLibrary.Items.Gear;
using NUnit.Framework;

namespace CombatSimulatorLibraryTests.Persons.Enemy
{
    public class EnemyTests : SetupTestFixture
    {
        [Test]
        [Order(3)]
        [Category("Person Creation")]
        public void CanCreateEnemy()
        {
            Assert.IsInstanceOf(typeof(CombatSimulatorLibrary.Persons.Enemy), Enemy);
            Assert.AreEqual("Goblin", Enemy.Name);
            Assert.AreEqual(2,        Enemy.Level);
            Assert.AreEqual(15,       Enemy.MaxHitPoints);
            Assert.AreEqual(15,       Enemy.CurrentHitPoints);
            Assert.AreEqual(8,        ((CombatSimulatorLibrary.Persons.Enemy)Enemy).ExperiencePointValue);
            Assert.GreaterOrEqual(((CombatSimulatorLibrary.Persons.Enemy)Enemy).CopperPieceValue, 0);
            Assert.LessOrEqual(((CombatSimulatorLibrary.Persons.Enemy)Enemy).CopperPieceValue, 200);
            Assert.AreEqual(3, Enemy.Inventory.Count);
            Assert.IsInstanceOf(typeof(Weapon), Enemy.EquippedWeapon);
            Assert.IsInstanceOf(typeof(Armor),  Enemy.EquippedArmor);
            Assert.IsInstanceOf(typeof(Shield), Enemy.EquippedShield);
        }
    }
}