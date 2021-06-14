using System;
using System.Security.Cryptography;
using CombatSimulatorLibrary.Base;

namespace CombatSimulatorLibrary.Persons
{
    public class Enemy : Person
    {
        public Enemy(
            string name,
            int level,
            int maxHitPoints
        ) : base(name, level, maxHitPoints)
        {
            CurrentHitPoints = maxHitPoints;
            ExperiencePointValue = level * 4;
            CopperPieceValue = RandomNumberGenerator.GetInt32(0, 200);
        }

        #region Properties

        /// <summary>
        /// How many experience points that the player gets for beating this enemy.
        /// </summary>
        public int ExperiencePointValue { get; set; }
        /// <summary>
        /// How many copper pieces the player gets for beating this enemy.
        /// </summary>
        public int CopperPieceValue { get; set; }

        #endregion Properties

        #region Methods



        #endregion Methods
    }
}
