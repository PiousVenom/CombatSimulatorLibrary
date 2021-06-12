using CombatSimulatorLibrary.Items;
using CombatSimulatorLibrary.Items.Gear;
using NUnit.Framework;

namespace CombatSimulatorLibraryTests
{
    public class ItemTest
    {
        [Test]
        public void SetSellValueTest()
        {
            var plate = new Armor(10) { Cost = 50 };

            plate.SetSellValue();
            plate.SetSellValue();

            Assert.That(plate.SellValue, Is.TypeOf<int>());
            Assert.AreEqual(17, plate.SellValue);
        }

        [Test]
        public void SwingWeaponTest()
        {
            var sword = new Weapon(10, 2, 20, "Long Sword");
            Assert.That(sword.SwingWeapon(), Is.TypeOf<int>());
            Assert.AreEqual("2 - 20", sword.DisplayDamage());
        }
    }
}