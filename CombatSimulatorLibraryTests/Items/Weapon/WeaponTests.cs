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
            Assert.AreEqual(10, Weapon.SellValue);
        }

        [Test]
        [Category("Item Specific")]
        public void SwingWeaponTest()
        {
            var swing = Weapon.SwingWeapon();

            Assert.That(swing, Is.TypeOf<int>());
            Assert.AreEqual("2 - 20", Weapon.DisplayDamage());
            Assert.GreaterOrEqual(swing, 2);
            Assert.LessOrEqual(swing, 20);
        }

        [Test]
        [Category("Currency Conversion")]
        public void WeaponCurrencyConversionTest()
        {
            Weapon.ConvertCurrency();
            Assert.AreEqual(0, Weapon.Copper);
            Assert.AreEqual(0, Weapon.Silver);
            Assert.AreEqual(1, Weapon.Gold);
            Assert.AreEqual(0, Weapon.Platinum);
        }
    }
}
