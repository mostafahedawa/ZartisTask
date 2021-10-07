namespace ZartisTask.Models
{
    public abstract class LandingArea
    {
        #region Properties
        // the size of the landing area
        public int Size { get; set; }

        // 2d array of type cell
        public Cell[,] TheGrid { get; set; }
        #endregion

        #region ctor
        public LandingArea()
        {
            // initial size of the board is defined by the config areaSize
            Size = Constant.AreaSize;
            // create a new 2D array of type cell
            TheGrid = new Cell[Size, Size];
            // fill the 2D array with new cells , each row
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    TheGrid[i, j] = new Cell(i, j)
                    {
                        LegalNextLand = false,
                        CurrentlyOccupied = false
                    };
                }
            }
        } 
        #endregion
    }
}