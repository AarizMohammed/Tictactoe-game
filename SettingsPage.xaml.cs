namespace TicTacToeGame;


public partial class SettingsPage : ContentPage
{
    List<Themes> AvailableThemes;
    string SelectedDifficulty;
    Color SelectedListCell;
    public SettingsPage()
    {
        InitializeComponent();
        AvailableThemes = new List<Themes>();
        GetThemes();
        ThemeList.ItemsSource = AvailableThemes;
        SelectedDifficulty = Settings.GameDifficulty.ToString();
    }

    void DifficultyPicker_SelectedIndexChanged(System.Object sender, System.EventArgs e)
    {
        switch (DifficultyPicker.SelectedItem)
        {
            case "Easy" :
                Settings.GameDifficulty = Difficulty.easy;
                break;
            case "Medium":
                Settings.GameDifficulty = Difficulty.medium;
                break;
            case "Hard":
                Settings.GameDifficulty = Difficulty.hard;
                break;
        }
    }

    void GetThemes()
    {
        AvailableThemes = ThemesRepository.GetAll();
    }


    void ThemeList_ItemSelected(System.Object sender, Microsoft.Maui.Controls.SelectedItemChangedEventArgs e)
    {
        Settings.SelectedTheme = (Themes)ThemeList.SelectedItem;
    }

    void ResetBtn_Clicked(System.Object sender, System.EventArgs e)
    {
        Settings.GameDifficulty = Difficulty.easy;
        Settings.SelectedTheme = ThemesRepository.DefaultTheme;
    }






}
