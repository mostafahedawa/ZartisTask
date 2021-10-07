using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZartisTask.Models
{
  public abstract class LandingArea
    {
        // the size of the landing area which will be 10x10
        public int Size { get; set; }
        // 2d array of type cell 
        public Cell[,] TheGrid { get; set; }
        
        public LandingArea()
        {
            // initial size of the board is defined by s.
            Size = Constant.AreaSize;
            // create a new 2D array of type cell
            TheGrid = new Cell[Size, Size];
            // fill the 2D array with new cells , each 
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
    }
}
