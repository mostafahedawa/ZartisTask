namespace ZartisTask.Models
{
    public class Cell
    {
        #region Properties
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public bool CurrentlyOccupied { get; set; }
        public bool LegalNextLand { get; set; }
        #endregion

        #region ctor
        public Cell(int x, int y)
        {
            RowNumber = x;
            ColumnNumber = y;
        } 
        #endregion
    }
}