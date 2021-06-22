using System;
using System.Security.Cryptography;
using CombatSimulatorLibrary.Interfaces;

namespace CombatSimulatorLibrary.Items.Gear
{
    /// <summary>
    /// Gear the players/enemies can use
    /// </summary>
    public class Gear : IGear,
                        ICommon
    {
        public Gear() => SetSellValue();

        /// <summary>
        /// If you use this contructor, you're doing it wrong
        /// </summary>
        /// <param name="costInCopper" type="int">How much copper it costs to buy</param>
        /// <param name="name" type="string">Name of the piece of gear</param>
        /// <param name="purpose" type="enum">Undefined/Weapon/Armor/Shield</param>
        public Gear(int costInCopper, string name, Purpose purpose)
        {
            CostInCopper = costInCopper;
            Name         = name;
            Purpose      = purpose;
        }

        /// <summary>
        /// Creates an instance of Gear. Meant as a constructor for Weapons
        /// </summary>
        /// <param name="costInCopper" type="int">How much copper it costs to buy</param>
        /// <param name="name" type="string">Name of the piece of gear</param>
        /// <param name="purpose" type="enum">Undefined/Weapon/Armor/Shield</param>
        /// <param name="minDamage" type="null|int">Minimum damage a weapon can do</param>
        /// <param name="maxDamage" type="null|int">Maximum damage a weapon can do</param>
        public Gear(int costInCopper, string name, Purpose purpose, int? minDamage, int? maxDamage)
        {
            CostInCopper = costInCopper;
            Name         = name;
            Purpose      = purpose;
            MinDamage    = minDamage;
            MaxDamage    = maxDamage;
            SetSellValue();
        }

        /// <summary>
        /// Creates an instance of Gear. Meant as a constructor for Armor/Shields
        /// </summary>
        /// <param name="costInCopper" type="int">How much copper it costs to buy</param>
        /// <param name="name" type="string">Name of the piece of gear</param>
        /// <param name="purpose" type="enum">Undefined/Weapon/Armor/Shield</param>
        /// <param name="defense" type="null|int">Defense provided by gear</param>
        public Gear(int costInCopper, string name, Purpose purpose, int? defense)
        {
            CostInCopper = costInCopper;
            Name         = name;
            Purpose      = purpose;
            Defense      = defense;
            SetSellValue();
        }

        /// <summary>
        /// Swings the weapon to do damage.
        /// </summary>
        /// <returns type="int">Returns the amount of damage dealt, random between Min and Max properties.</returns>
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

        /// <summary>
        /// Set's the sell value of a piece of gear
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private void SetSellValue()
        {
            SellValue = Purpose switch {
                Purpose.Shield         => 15 * CostInCopper / 100,
                Purpose.Weapon         => 10 * CostInCopper / 100,
                Purpose.Armor          => 35 * CostInCopper / 100,
                Purpose.Undefined or _ => throw new ArgumentOutOfRangeException(),
            };
        }

        /// <summary>
        /// Displays information about the gear
        /// </summary>
        /// <returns type="string">Information pertaining to the gear based upon it's Purpose(Undefined/Weapon/Armor/Shield)</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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