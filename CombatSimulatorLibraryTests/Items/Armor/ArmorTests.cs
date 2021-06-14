using NUnit.Framework;

namespace CombatSimulatorLibraryTests.Items.Armor
{
    public class ArmorTests : SetupTestFixture
    {
        [Test]
        [Category("Item Creation")]
        public void CanCreateArmorTest()
        {
            Assert.IsInstanceOf(typeof(CombatSimulatorLibrary.Items.Gear.Armor), Armor);
            Assert.AreEqual("Plate Armor", Armor.Name);
            Assert.IsTrue(Armor.IsEquipped);
        }

        [Test]
        [Category("Sell Items")]
        public void SetArmorSellValueTest()
        {
            Armor.SetSellValue();

            Assert.That(Armor.SellValue, Is.TypeOf<int>());
            Assert.AreEqual(42, Armor.SellValue);
        }

        [Test]
        [Category("Item Specific")]
        public void ArmorDefenseTest()
        {
            Assert.AreEqual(string.Concat("Armor Defense Rating: ", 10), Armor.DisplayArmor());
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
    }
}
