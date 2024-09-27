using System;
namespace TicTacToeGame
{
    public enum Result // enum for all the possible results of the game
    {
        win, draw, none
    }

    public class Board
    {
        public string[,] GameGrid { get; private set; } //2D array for the game grid
        public Board()
        {
            GameGrid = new string[3, 3];
            InitializeBoard();
        }

        public void InitializeBoard() //method to initialize the board when the game will be started
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    GameGrid[i, j] = " ";
        }

        public void PlaceMove(int[] move, string symbol) // method to place a symbol in the grid
        {
            GameGrid[row, column] = symbol;
        }

        public bool IsCellEmpty(int row, int column) // method to check if cell is empty
        {
            if (GameGrid[row, column] ==" " )
                return true;
            return false;
        }

        public void ClearCell(int row, int column) // method to clear cell if needed
        {
            GameGrid[row, column] = " " ;
        }

        public Result GetGameStatus(string symbol)// method to check the result of the based on the current game gridg
        {
            for (int i = 0; i < 3; i++)
            {
                if (GameGrid[i, 0] == symbol && GameGrid[i, 1] == symbol && GameGrid[i, 2] == symbol)
                    return Result.win;

                if (GameGrid[0, i] == symbol && GameGrid[1, i] == symbol && GameGrid[2, i] == symbol)
                    return Result.win;
            }

            if (GameGrid[0, 0] == symbol && GameGrid[1, 1] == symbol && GameGrid[2, 2] == symbol ||
                GameGrid[0, 2] == symbol && GameGrid[1, 1] == symbol && GameGrid[2, 0] == symbol)
                return Result.win;

            if (!isBoardFull())
            {
                return Result.none;
            }
            return Result.draw;

        }

        public bool isBoardFull()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (GameGrid[i, j] == " ")
                        return false;
            return true;
        }
    }
}