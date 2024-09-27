using System;
namespace TicTacToeGame
{
	public abstract class Player
    	{
        public string Symbol { get; set; }
        public Board PlayingBoard { get; set; }
        public int[] CurrentMove { get; set; }
        public Color SymbolColor { get; set; }
        public string Name = "Computer";
        public Player(Board board)
        {
            PlayingBoard = board;
            CurrentMove = new int[2];
        }

        public abstract void MakeMove();
        public abstract void SetCoordinates(int row, int column);
        }

}
