using System;
using ZartisTask;
using ZartisTask.Models;

namespace Zartis.ConsoleApp
{
    class Program
    {

        
        static LandingPlatform landingPlatform = new LandingPlatform();
        static void Main(string[] args)
        {

            // show the empty platform
            printBoard(landingPlatform);
            // ask the rocket for an x any y coordinate where will be landded in
            string i = "y";
            while (i != "n")
            {
                Cell currentCell = SetCurrentCell();
                //currentCell.CurrentlyOccupied = true;

                //calculate all legal slots for the rockets 
                var result =  landingPlatform.MarkLegalLanding(currentCell, "Rocket 1");
                Console.WriteLine(result);
                //print the platform use an X for occupied slots , user + for legal slot
                printBoard(landingPlatform);
                Console.WriteLine("Press y for continue or n for close");
                i = Console.ReadLine();

            }
            
            // wait for another enter key 

        }


        private static void printBoards(LandingPlatform chessBoard)
        {
            // Print the chess board to the console. Use x for the piece location. 
            Console.WriteLine("=================================");

            for (int i = 0; i < chessBoard.Size; i++)
            {
                Console.WriteLine("+---+---+---+---+---+---+---+---+---+---+");
                Console.Write("|");
                for (int j = 0; j < chessBoard.Size; j++)
                {
                    Cell c = chessBoard.TheGrid[i, j];

                    if (c.CurrentlyOccupied == true)
                    {
                        Console.Write(" X ");
                    }
                    else if (c.LegalNextLand == true)
                    {
                        Console.Write(" + ");
                    }
                    else
                    {
                        Console.Write(" . ");
                    }
                    Console.Write("|");
                }

                Console.WriteLine();
            }
            Console.WriteLine("+---+---+---+---+---+---+---+---+---+---+");

            Console.WriteLine("=================================");
        }

        private static void printBoard(LandingPlatform board)
        {
            for (int i = 0; i < Constant.AreaSize; i++)
            {
                for (int b = 0; b < Constant.AreaSize; b++)
                {
                    Console.Write("+---");
                }
                Console.Write("+");
                Console.WriteLine();
                Console.Write("|");

                for (int j = 0; j < Constant.AreaSize; j++)
                {

                    Cell c = board.TheGrid[i, j];

                    if (c.CurrentlyOccupied == true)
                    {
                        Console.Write(" X ");
                    }
                    else if (c.LegalNextLand == true)
                    {
                        Console.Write(" + ");
                    }
                    else
                    {
                        Console.Write("   ");

                    }
                    Console.Write("|");
                }

                Console.WriteLine();
            }

            for (int d = 0; d < Constant.AreaSize; d++)
            {
                Console.Write("+---");
            }
            Console.Write("+");
            Console.WriteLine();

            Console.WriteLine("==========================================");
        }


        private static void PrintPlatform(LandingPlatform platform)
        {
            for (int i = 0; i < platform.Size; i++)
            {
                for (int j = 0; j < platform.Size; j++)
                {
                    Cell c = platform.TheGrid[i, j];
                    if (c.CurrentlyOccupied)
                    {
                        Console.Write('X');
                    }
                    else if (c.LegalNextLand)
                    {
                        Console.Write('+');
                    }
                    else
                    {
                        Console.Write('-');
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("==========================================");

        }

        private static Cell SetCurrentCell()
        {
            // get the x coordinates from the user . return a cell location
            Console.WriteLine("Enter the current Row number");
            int currentRow = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the current Column number");
            int currentColumn = int.Parse(Console.ReadLine());

            return  landingPlatform.TheGrid[currentRow, currentColumn];
        }
    }
}
