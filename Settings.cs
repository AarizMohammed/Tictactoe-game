using System;
using static Android.Content.Res.Resources;

namespace TicTacToeGame
{
	public class Settings
	{
        public static Difficulty GameDifficulty { get; set; }
        public static Color BackGroundColor { get; set; }
        public static Themes SelectedTheme { get; set; }
        static Settings()
        {
            GameDifficulty = Difficulty.easy;
            SelectedTheme = ThemesRepository.DefaultTheme;

        }
    }
}

