using ZartisTask.Enum;

namespace ZartisTask.Models
{
    public class LandingPlatform : LandingArea
    {
        public LandingPlatform()
        {
            // initialize the size of the landing platform
            Size = Constant.PlatformSize;

            // mark the landing platform slots on the landing area
            for (int i = Constant.PlatformStartingPoint; i < Size + Constant.PlatformStartingPoint; i++)
            {
                for (int j = Constant.PlatformStartingPoint; j < Size + Constant.PlatformStartingPoint; j++)
                {
                    TheGrid[i, j] = new Cell(i, j)
                    {
                        LegalNextLand = true,
                        CurrentlyOccupied = false
                    };
                }
            }
        }
        public string MarkLegalLanding(Cell currentCell, string rocket)
        {
            if (IsSafeLand(currentCell.RowNumber, currentCell.ColumnNumber))
            {
                if (currentCell.LegalNextLand)
                {
                    TheGrid[currentCell.RowNumber, currentCell.ColumnNumber - 1].LegalNextLand = false;
                    TheGrid[currentCell.RowNumber, currentCell.ColumnNumber + 1].LegalNextLand = false;

                    TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].LegalNextLand = false;
                    TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].LegalNextLand = false;
                    TheGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber].LegalNextLand = false;

                    TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber].LegalNextLand = false;
                    TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].LegalNextLand = false;
                    TheGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].LegalNextLand = false;

                    TheGrid[currentCell.RowNumber, currentCell.ColumnNumber].CurrentlyOccupied = true;
                    return FormateMessage(currentCell.RowNumber, currentCell.ColumnNumber, Status.Avilable);
                }
                else
                {
                    return FormateMessage(currentCell.RowNumber, currentCell.ColumnNumber, Status.Clash);
                }
            }
            else
                return FormateMessage(currentCell.RowNumber, currentCell.ColumnNumber, Status.NotAvilable);
        }

        private bool IsSafeLand(int rowNumber, int column)
        {
            return rowNumber>= Constant.PlatformStartingPoint && column >= Constant.PlatformStartingPoint && rowNumber <= Size-1 + Constant.PlatformStartingPoint && column <= Size-1 + Constant.PlatformStartingPoint;
        }

        private static string FormateMessage(int x, int y, Status status)
        {
            string message = string.Empty;
            switch (status)
            {
                case Status.Avilable:
                    message = "Ok For Landing";
                    break;

                case Status.Clash:
                    message = "clash";
                    break;

                case Status.NotAvilable:
                    message = "out of platform";
                    break;

                default:
                    break;
            }

            return "The Cordinate (" + x + "," + y + ") is " + message;
        }
    }
}