namespace CombatSimulatorLibrary.Interfaces
{
    public interface IItem
    {
        #region Properties 

        string Name { get; set; }
        int CostInCopper { get; set; }
        int SellValue { get; set; }
        bool IsEquipped { get; set; }
        int Gold { get; set; }
        int Platinum { get; set; }
        int Silver { get; set; }
        int Copper { get; set; }

        #endregion Properties 

        #region Methods

        void SetSellValue();

        #endregion Methods
    }
}