using System;
using System.Security.Cryptography;
using CombatSimulatorLibrary.Interfaces;

namespace CombatSimulatorLibrary.Items.Gear
{
    public class Gear : IGear,
                        ICommon
    {
        public Gear(int costInCopper, string name, Purpose purpose)
        {
            CostInCopper = costInCopper;
            Name         = name;
            Purpose      = purpose;
        }

        public Gear(int costInCopper, string name, Purpose purpose, int? minDamage, int? maxDamage)
        {
            CostInCopper = costInCopper;
            Name         = name;
            Purpose      = purpose;
            MinDamage    = minDamage;
            MaxDamage    = maxDamage;
        }

        public Gear(int costInCopper, string name, Purpose purpose, int? defense)
        {
            CostInCopper = costInCopper;
            Name         = name;
            Purpose      = purpose;
            Defense      = defense;
        }

        /// <summary>
        /// Swings the weapon to do damage.
        /// </summary>
        /// <returns>Returns the amount of damage dealt, random between Min and Max properties.</returns>
        public int SwingWeapon()
        {
            if(Purpose is not Purpose.Weapon)
            {
                throw new ArgumentOutOfRangeException();
            }

            if(MinDamage is null || MaxDamage is null)
            {
                throw new ArgumentNullException();
            }

            var random = RandomNumberGenerator.GetInt32((int) MinDamage, (int) MaxDamage);

            return random;
        }

        public void SetSellValue()
        {
            SellValue = Purpose switch {
                Purpose.Shield         => 15 * CostInCopper / 100,
                Purpose.Weapon         => 10 * CostInCopper / 100,
                Purpose.Armor          => 35 * CostInCopper / 100,
                Purpose.Undefined or _ => throw new ArgumentOutOfRangeException(),
            };
        }

        public string Display()
        {
            return Purpose switch {
                Purpose.Shield         => string.Concat("Shield Defense Rating: ", Defense),
                Purpose.Weapon         => string.Concat("Damage: ", MinDamage, " - ", MaxDamage, " points"),
                Purpose.Armor          => string.Concat("Armor Defense Rating: ", Defense),
                Purpose.Undefined or _ => throw new ArgumentOutOfRangeException(),
            };
        }

        public  Purpose Purpose      { get; }
        public  int     CostInCopper { get; }
        public  string  Name         { get; }
        public  int     SellValue    { get; private set; }
        public  bool    IsEquipped   { get; set; }
        public  int     Gold         { get; set; }
        public  int     Platinum     { get; set; }
        public  int     Silver       { get; set; }
        public  int     Copper       { get; set; }
        public  int?    Defense      { get; }
        private int?    MinDamage    { get; }
        private int?    MaxDamage    { get; }
    }
}