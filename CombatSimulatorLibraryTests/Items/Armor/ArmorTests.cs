using NUnit.Framework;

namespace CombatSimulatorLibraryTests.Items.Armor
{
    public class ArmorTests : SetupTestFixture
    {
        [Test]
        [Category("Item Specific")]
        public void ArmorDefenseTest()
        {
            Assert.AreEqual(string.Concat("Armor Defense Rating: ", 10),
                            ((CombatSimulatorLibrary.Items.Gear.Armor) Armor).DisplayArmor());
        }

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
            Assert.AreEqual(70, Armor.SellValue);
        }
    }
}