using System;
namespace TicTacToeGame
{
    	public enum Difficulty
	{
		easy, medium, hard
	}

	public class ComputerPlayer:Player
	{
		public Difficulty DifficultyLevel { get; set; }
		private string _opponentSymbol;
		public string OpponentSymbol
		{
			get
			{
				return _opponentSymbol;
			}
			set
			{
				_opponentSymbol = (Symbol == "X") ? "O" : "X";
			}
		}
        Random random = new Random();
        private int[] ComputerWinningMove = new int[2];
		private int[] HumanWinningMove = new int[2];
		public GridCoordinates coordinates { get; set; }
		public ComputerPlayer(Board board):base (board)
		{
			PlayingBoard = board;
			DifficultyLevel = Settings.GameDifficulty;
		}

        public override void MakeMove()
        {

            if (DifficultyLevel == Difficulty.easy)
				PlayEasyMove(PlayingBoard);
			else if (DifficultyLevel == Difficulty.medium)
				PlayMediumMove(PlayingBoard);
			else
				PlayHardMove(PlayingBoard);
			PlayingBoard.PlaceMove(CurrentMove, Symbol);
        }

        public override void SetCoordinates(int row, int column)
        {
            CurrentMove[0] = row;
			CurrentMove[1] = column;
			if (row == 0)
			{
				if (column == 0)
					coordinates = GridCoordinates.Grid00;
				else if (column == 1)
					coordinates = GridCoordinates.Grid01;
				else
					coordinates = GridCoordinates.Grid02;
			}
			else if(row == 1)
			{
				if (column == 0)
					coordinates = GridCoordinates.Grid10;
				else if (column == 1)
					coordinates = GridCoordinates.Grid11;
				else
					coordinates = GridCoordinates.Grid12;
			}
			else
			{
				if (column == 0)
					coordinates = GridCoordinates.Grid20;
				else if (column == 1)
					coordinates = GridCoordinates.Grid21;
				else
					coordinates = GridCoordinates.Grid22;
			}
        }

        public void PlayEasyMove(Board board)
		{
			MakeRandomMove(board);
		}

		public void PlayMediumMove(Board board)
		{
			if (CheckIfWinning(board, OpponentSymbol))
				MakeBlockingMove(board);

			else
				MakeRandomMove(board);
		}

		public void PlayHardMove(Board board)
		{
			if (CheckIfWinning(board, OpponentSymbol))
				MakeBlockingMove(board);
			else if (CheckIfWinning(board, Symbol))
				MakeWinningMove(board);
			else
				MakeRandomMove(board);
		}

		private void MakeWinningMove(Board board)
		{
			int row = ComputerWinningMove[0];
			int column = ComputerWinningMove[1];
			if (PlayingBoard.IsCellEmpty(ComputerWinningMove[0], ComputerWinningMove[1]))
				SetCoordinates(row, column);
			else
				MakeRandomMove(board);
		}


		private bool CheckIfWinning(Board board, string symbol)
		{
            for (int i = 0; i < 3; i++)
            {
				for (int j = 0; j < 3; j++)
				{
					if (board.IsCellEmpty(i, j))
					{
						CurrentMove[0] = i;
						CurrentMove[1] = j;
						board.PlaceMove(CurrentMove, Symbol);
						if (board.GetGameStatus(Symbol) == Result.win)
						{
							if (symbol == Symbol)
							{
								ComputerWinningMove[0] = i;
								ComputerWinningMove[1] = j;
							}
							else
							{
								HumanWinningMove[0] = i;
								HumanWinningMove[1] = j;
							}
							board.ClearCell(i, j);
							return true;
						}

						board.ClearCell(i, j);
					}
				}
			}
			return false;
		}

		private void MakeBlockingMove(Board board)
		{
			
			int row = HumanWinningMove[0];
			int column = HumanWinningMove[1];
			if (PlayingBoard.IsCellEmpty(HumanWinningMove[0], HumanWinningMove[1]))
				SetCoordinates(row, column);
			else
				MakeRandomMove(board);
		}

		private void MakeRandomMove(Board board)
		{

			int row;
			int column;
			

			do
			{
				row = random.Next(0, 3);
				column = random.Next(0, 3);
			}
			while (!board.IsCellEmpty(row, column) && !board.isBoardFull());

			SetCoordinates(row, column);
		}

    }
    }
}

