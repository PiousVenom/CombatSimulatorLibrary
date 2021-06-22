namespace CombatSimulatorLibrary.Interfaces
{
    public enum Purpose
    {
        Undefined,
        Shield,
        Weapon,
        Armor,
    }

    public interface IGear
    {
        #region Methods

        #endregion Methods

        #region Properties

        int     CostInCopper { get; }
        string  Name         { get; }
        int     SellValue    { get; }
        bool    IsEquipped   { get; set; }
        int     Gold         { get; set; }
        int     Platinum     { get; set; }
        int     Silver       { get; set; }
        int     Copper       { get; set; }
        int?    Defense      { get; }
        Purpose Purpose      { get; }

        int SwingWeapon();

        string Display();

        #endregion Properties
    }
}