using System;
using CombatSimulatorLibrary.Interfaces;
using CombatSimulatorLibrary.Items.Gear;
using NUnit.Framework;

namespace CombatSimulatorLibraryTests.Items.Base
{
    public class GearTest : SetupTestFixture
    {
        private static void CurrencyTesting(IGear gear)
        {
            var (copper, silver, gold, platinum) = ICommon.ConvertCurrency(gear.CostInCopper);
            gear.Copper                          = copper;
            gear.Silver                          = silver;
            gear.Gold                            = gold;
            gear.Platinum                        = platinum;
            
            Assert.AreEqual(0, gear.Copper);
            Assert.AreEqual(0, gear.Silver);
            Assert.AreEqual(2, gear.Gold);
            Assert.AreEqual(0, gear.Platinum);
        }

        [Test]
        [Category("Currency Conversion")]
        public void ItemCurrencyConversionTest()
        {
            CurrencyTesting(Weapon);
            CurrencyTesting(Shield);
            CurrencyTesting(Armor);
        }
        
        [Test]
        [Category("Item Creation")]
        public void CanCreateGearTest()
        {
            Assert.AreEqual(Weapon.Purpose, Purpose.Weapon);
            Assert.AreEqual("Long Sword", Weapon.Name);
            Assert.IsTrue(Weapon.IsEquipped);
        }
        
        [Test]
        [Category("Item Specific")]
        public void SwingWeaponTest()
        {
            var swing     = Weapon.SwingWeapon();

            Assert.Throws<ArgumentOutOfRangeException>(() => Armor.SwingWeapon());
            Assert.Throws<ArgumentNullException>(() => BrokeWeapon.SwingWeapon());
            Assert.That(swing, Is.TypeOf<int>());
            Assert.GreaterOrEqual(swing, 2);
            Assert.LessOrEqual(swing, 20);
        }
        
        [Test]
        [Category("Item Specific")]
        public void GearDisplayTest()
        {
           GearDisplay(Shield);
           GearDisplay(Weapon);
           GearDisplay(Armor);
           GearDisplay(NoPurpose);
        }

        [Test]
        public void GetSellValue()
        {
            Assert.AreEqual(20, Weapon.SellValue);
            Assert.AreEqual(70, Armor.SellValue);
            Assert.AreEqual(30, Shield.SellValue);
            Assert.That(() => new Gear(), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        private static void GearDisplay(IGear gear)
        {
            switch(gear.Purpose)
            {
                case Purpose.Weapon:
                    Assert.AreEqual("Damage: 2 - 20 points", gear.Display());
                    break;
                case Purpose.Armor:
                    Assert.AreEqual(string.Concat("Armor Defense Rating: ", 10), gear.Display());
                    break;
                case Purpose.Shield:
                    Assert.AreEqual(string.Concat("Shield Defense Rating: ", 10), gear.Display());
                    break;
                default:
                    Assert.Throws<ArgumentOutOfRangeException>(() => gear.Display());
                    break;
            }
        }
    }
}