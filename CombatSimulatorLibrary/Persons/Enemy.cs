using CombatSimulatorLibrary.Base;

namespace CombatSimulatorLibrary.Persons
{
    public class Enemy : Person
    {
        #region Properties

        /// <summary>
        /// How many experience points that the player gets for beating this enemy.
        /// </summary>
        public int ExperiencePointValue { get; set; }
        /// <summary>
        /// How many gold pieces the player gets for beating this enemy.
        /// </summary>
        public int GoldPieceValue { get; set; }
        /// <summary>
        /// How many copper pieces the player gets for beating this enemy.
        /// </summary>
        public int CopperPieceValue { get; set; }
        /// <summary>
        /// How many silver pieces the player gets for beating this enemy.
        /// </summary>
        public int SilverPieceValue { get; set; }
        /// <summary>
        /// How many platinum pieces the player gets for beating this enemy.
        /// </summary>
        public int PlatinumPieceValue { get; set; }
        #endregion Properties

        #region Methods



        #endregion Methods
    }
}
