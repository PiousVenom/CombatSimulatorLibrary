using CombatSimulatorLibrary.Items.Gear;
using NUnit.Framework;

namespace CombatSimulatorLibraryTests
{
    public class ItemTests : SetupTestFixture
    {
        #region Creation Tests

        [Test]
        [Category("Item Creation")]
        public void CanCreateWeaponTest()
        {
            Assert.IsInstanceOf(typeof(Weapon), Weapon);
            Assert.AreEqual("Long Sword", Weapon.Name);
            Assert.IsTrue(Weapon.IsEquipped);
        }

        [Test]
        [Category("Item Creation")]
        public void CanCreateArmorTest()
        {
            Assert.IsInstanceOf(typeof(Armor), Armor);
            Assert.AreEqual("Plate Armor", Armor.Name);
            Assert.IsTrue(Armor.IsEquipped);
        }

        [Test]
        [Category("Item Creation")]
        public void CanCreateShieldTest()
        {
            Assert.IsInstanceOf(typeof(Shield), Shield);
            Assert.AreEqual("Buckler", Shield.Name);
            Assert.IsTrue(Shield.IsEquipped);
        }

        #endregion Creation Tests

        #region Sell Item Tests

        [Test]
        [Category("Sell Items")]
        public void SetArmorSellValueTest()
        {
            Armor.SetSellValue();

            Assert.That(Armor.SellValue, Is.TypeOf<int>());
            Assert.AreEqual(42, Armor.SellValue);
        }

        [Test]
        [Category("Sell Items")]
        public void SetShieldSellValueTest()
        {
            Shield.SetSellValue();

            Assert.That(Shield.SellValue, Is.TypeOf<int>());
            Assert.AreEqual(30, Shield.SellValue);
        }

        [Test]
        [Category("Sell Items")]
        public void SetWeaponSellValueTest()
        {
            Weapon.SetSellValue();

            Assert.That(Weapon.SellValue, Is.TypeOf<int>());
            Assert.AreEqual(10, Weapon.SellValue);
        }

        #endregion Sell Item Tests

        #region Item Specific Tests

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
        [Category("Item Specific")]
        public void ArmorDefenseTest()
        {
            Assert.AreEqual(string.Concat("Armor Defense Rating: ", 10), Armor.DisplayArmor());
        }

        [Test]
        [Category("Item Specific")]
        public void ShieldDefenseTest()
        {
            Assert.AreEqual(string.Concat("Shield Defense Rating: ", 10), Shield.DisplayShield());
        }

        #endregion Item Specific Tests

        #region Currency Conversion Test

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

        [Test]
        [Category("Currency Conversion")]
        public void ArmorCurrencyConversionTest()
        {
            Armor.ConvertCurrency();
            Assert.AreEqual(0, Armor.Copper);
            Assert.AreEqual(2, Armor.Silver);
            Assert.AreEqual(1, Armor.Gold);
            Assert.AreEqual(0, Armor.Platinum);
        }

        [Test]
        [Category("Currency Conversion")]
        public void ShieldCurrencyConversionTest()
        {
            Shield.ConvertCurrency();
            Assert.AreEqual(0, Shield.Copper);
            Assert.AreEqual(0, Shield.Silver);
            Assert.AreEqual(2, Shield.Gold);
            Assert.AreEqual(0, Shield.Platinum);
        }

        #endregion
    }
}