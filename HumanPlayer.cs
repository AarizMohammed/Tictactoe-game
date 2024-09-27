using System;
namespace TicTacToeGame
{
    using System;

    public class HumanPlayer
    {
        public string Name { get; set; }
        public char Symbol { get; set; }
        public string test { get; set; }

        public HumanPlayer(string name, Board board)
        {
            Name = name;
            Symbol = symbol;
            test = "xyz";
        }

        
        public void HandleMove(int row, int column)
        {
            Console.WriteLine($"{Name}'s turn ({Symbol}).  ({row}, {column}).");
            
            //todo: update the board
        }


    }

}

