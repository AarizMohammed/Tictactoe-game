
namespace TicTacToeGame;
public enum GridCoordinates
{
    Grid00, Grid01, Grid02,
    Grid10, Grid11, Grid12,
    Grid20, Grid21, Grid22
}
public partial class HumanVsComputerMode : ContentPage
{
    Game game;
    Board board;
    HumanPlayer humanPlayer;
    ComputerPlayer computerPlayer;
    private TaskCompletionSource<bool> GridBtnPressed;
    public string PlayerName { get; set; }

    public HumanVsComputerMode()
    {
        InitializeComponent();
        board = new Board();
        humanPlayer = new HumanPlayer(PlayerName,board);
        computerPlayer = new ComputerPlayer(board);
        game = new Game(humanPlayer, computerPlayer, board);
        GridBtnPressed = new TaskCompletionSource<bool>();
        playGame();
    }

    void GridBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        Button clickedButton = (Button)sender;
        clickedButton.Text = humanPlayer.Symbol;
        int col = Grid.GetColumn(clickedButton);
        int row = Grid.GetRow(clickedButton);
        game.HumanPlayerMove(row, col);
        DisableBtn(clickedButton);
        GridBtnPressed.SetResult(true);  
    }

    public async Task WaitForButtonPressAsync()
    {
        await GridBtnPressed.Task;
        GridBtnPressed = new TaskCompletionSource<bool>();
    }

    void PlaceComputerMove()
    {
        game.ComputerPlayerMove();
        switch (computerPlayer.coordinates)
        {
            case GridCoordinates.Grid00:
                Grid00Btn.Text = computerPlayer.Symbol;
                DisableBtn(Grid00Btn);

                break;
            case GridCoordinates.Grid01:
                Grid01Btn.Text = computerPlayer.Symbol;
                DisableBtn(Grid01Btn);
                break;
            case GridCoordinates.Grid02:
                Grid02Btn.Text = computerPlayer.Symbol;
                DisableBtn(Grid02Btn);

                break;
            case GridCoordinates.Grid10:
                Grid10Btn.Text = computerPlayer.Symbol;
                DisableBtn(Grid10Btn);

                break;
            case GridCoordinates.Grid11:
                Grid11Btn.Text = computerPlayer.Symbol;
                DisableBtn(Grid11Btn);

                break;
            case GridCoordinates.Grid12:
                Grid12Btn.Text = computerPlayer.Symbol;
                DisableBtn(Grid12Btn);
                break;
            case GridCoordinates.Grid20:
                Grid20Btn.Text = computerPlayer.Symbol;
                DisableBtn(Grid20Btn);
                break;
            case GridCoordinates.Grid21:
                Grid21Btn.Text = computerPlayer.Symbol;
                DisableBtn(Grid21Btn);
                break;
            case GridCoordinates.Grid22:
                Grid22Btn.Text = computerPlayer.Symbol;
                DisableBtn(Grid22Btn);
                break;
        }


        void DisableBtn(Button button)
        {
            button.IsEnabled = false;
            button.TextColor = (button.IsEnabled) ? Color.Parse("Purple") : Color.Parse("Purple");
        }

        async Task PlayGame()
        {
            while (!game.isGameOver())
            {
                if (game.GetCurrentPlayer() == humanPlayer)
                {
                    await WaitForButtonPressAsync();
                    game.SwitchPlayer();
                }
                else
                {
                    PlaceComputerMove();
                    game.SwitchPlayer();
                }
            }

            _ = DisplayAlert("yay", "kgh", "yes sir");
            ResetGame();


        }

        void ResetGame()
        {
            board.InitializeBoard();
            Grid00Btn.Text = Grid01Btn.Text = Grid02Btn.Text = Grid10Btn.Text = Grid11Btn.Text = Grid12Btn.Text = Grid20Btn.Text = Grid21Btn.Text = Grid22Btn.Text = " ";
            Grid00Btn.IsEnabled = Grid01Btn.IsEnabled = Grid02Btn.IsEnabled = Grid10Btn.IsEnabled = Grid11Btn.IsEnabled
                = Grid12Btn.IsEnabled = Grid20Btn.IsEnabled = Grid21Btn.IsEnabled = Grid22Btn.IsEnabled = true;

        }

    }
    }