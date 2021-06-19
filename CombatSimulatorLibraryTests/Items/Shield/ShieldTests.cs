using NUnit.Framework;

namespace CombatSimulatorLibraryTests.Items.Shield
{
    public class ShieldTests : SetupTestFixture
    {
        [Test]
        [Category("Item Creation")]
        public void CanCreateShieldTest()
        {
            Assert.IsInstanceOf(typeof(CombatSimulatorLibrary.Items.Gear.Shield), Shield);
            Assert.AreEqual("Buckler", Shield.Name);
            Assert.IsTrue(Shield.IsEquipped);
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
        [Category("Item Specific")]
        public void ShieldDefenseTest()
        {
            Assert.AreEqual(string.Concat("Shield Defense Rating: ", 10),
                            ((CombatSimulatorLibrary.Items.Gear.Shield) Shield).DisplayShield());
        }
    }
}