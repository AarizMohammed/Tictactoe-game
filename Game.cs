using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeGame
{
    public class Game
    {
        public HumanPlayer humanPlayer { get; set; }
        public ComputerPlayer computerPlayer { get; set; }
        Player CurrentPlayer { get; set; }
        public Board GameBoard { get; set; }
        public Player[] Players { get; set; }
        Random generator = new Random();

        public Game(HumanPlayer human, ComputerPlayer computer, Board board)
        {
            humanPlayer = human;
            computerPlayer = computer;
            GameBoard = board;
            Players = new Player[2] { humanPlayer, computerPlayer };
            CurrentPlayer = Players[generator.Next(0, 2)];
            AssignSymbols();
        }

        public Player GetCurrentPlayer()
        {
            return CurrentPlayer;
        }

        private void AssignSymbols()
        {
            string[] gameSymbols = new string[2] { "O", "X" };
            int randomIndex = generator.Next(0, 2);
            humanPlayer.Symbol = gameSymbols[randomIndex];
            computerPlayer.Symbol = (humanPlayer.Symbol == "O") ? "X" : "O";
        }

        public void HumanPlayerMove(int row, int column)
        {
            //if (GameBoard.GetGameStatus(humanPlayer.Symbol) != Result.none)
            //{
            humanPlayer.SetCoordinates(row, column);
            humanPlayer.MakeMove();
            //}

        }

        public void ComputerPlayerMove()
        {
            //if(GameBoard.GetGameStatus(computerPlayer.Symbol) != Result.none)
            computerPlayer.MakeMove();
        }

        public void changeCurrentPlayer()
        {
            CurrentPlayer = (CurrentPlayer == humanPlayer) ? computerPlayer : humanPlayer;
        }

        public bool isGameOver()
        {
            if (GameBoard.GetGameStatus(CurrentPlayer.Symbol) == Result.none)
                return false;
            else
                return true;
        }

        public void SwitchPlayer()
        {
            CurrentPlayer = (CurrentPlayer == humanPlayer) ? computerPlayer : humanPlayer;
        }
    }
}