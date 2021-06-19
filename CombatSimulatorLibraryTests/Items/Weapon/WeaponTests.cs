using NUnit.Framework;

namespace CombatSimulatorLibraryTests.Items.Weapon
{
    public class WeaponTests : SetupTestFixture
    {
        [Test]
        [Category("Item Creation")]
        public void CanCreateWeaponTest()
        {
            Assert.IsInstanceOf(typeof(CombatSimulatorLibrary.Items.Gear.Weapon), Weapon);
            Assert.AreEqual("Long Sword", Weapon.Name);
            Assert.IsTrue(Weapon.IsEquipped);
        }

        [Test]
        [Category("Sell Items")]
        public void SetWeaponSellValueTest()
        {
            Weapon.SetSellValue();

            Assert.That(Weapon.SellValue, Is.TypeOf<int>());
            Assert.AreEqual(20, Weapon.SellValue);
        }

        [Test]
        [Category("Item Specific")]
        public void SwingWeaponTest()
        {
            var swing = ((CombatSimulatorLibrary.Items.Gear.Weapon) Weapon).SwingWeapon();

            Assert.That(swing, Is.TypeOf<int>());
            Assert.AreEqual("2 - 20", ((CombatSimulatorLibrary.Items.Gear.Weapon) Weapon).DisplayDamage());
            Assert.GreaterOrEqual(swing, 2);
            Assert.LessOrEqual(swing, 20);
        }
    }
}