namespace CombatSimulatorLibrary.Interfaces
{
    public interface IItem
    {
        #region Methods

        void SetSellValue();

        #endregion Methods

        #region Properties

        string Name       { get; }
        int    SellValue  { get; }
        bool   IsEquipped { get; set; }
        int    Gold       { get; }
        int    Platinum   { get; }
        int    Silver     { get; }
        int    Copper     { get; }

        #endregion Properties
    }
}