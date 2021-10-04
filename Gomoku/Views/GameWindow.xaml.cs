using Gomoku.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Gomoku.Views
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private readonly GameViewModel _gameViewModel;
        private readonly BrushConverter _brushConverter;
        private readonly FontWeightConverter _fontConverter;

        public GameWindow(GameViewModel gameViewModel)
        {
            InitializeComponent();
            _brushConverter = new BrushConverter();
            _fontConverter = new FontWeightConverter();
            _gameViewModel = gameViewModel;
            _gameViewModel.CurrentPlayerName = _gameViewModel.Player1Name;
            DataContext = _gameViewModel;

            for (int rowIterator = 0; rowIterator < 16; rowIterator++)
            {
                var row = new RowDefinition();
                GameGrid.RowDefinitions.Add(row);
                var column = new ColumnDefinition();
                GameGrid.ColumnDefinitions.Add(column);

                for (int columnIterator = 0; columnIterator < 16; columnIterator++)
                {
                    if (rowIterator == 0 || columnIterator == 0)
                    {
                        var label = new Label();
                        GameGrid.Children.Add(label);
                        label.Height = 40;
                        label.Width = 40;
                        Grid.SetRow(label, rowIterator);
                        Grid.SetColumn(label, columnIterator);
                        if (columnIterator != 0)
                        {
                            label.Content = columnIterator;
                        }
                        else if (rowIterator != 0)
                        {
                            label.Content = Convert.ToChar(rowIterator + 64);
                        }
                    }
                    else
                    {
                        var button = new Button();
                        GameGrid.Children.Add(button);
                        button.Height = 40;
                        button.Width = 40;
                        Grid.SetRow(button, rowIterator);
                        Grid.SetColumn(button, columnIterator);
                        button.Click += Game_Button_Click;
                        button.MouseEnter += Game_Button_MouseEnter;                        
                    }
                }
            }
        }

        private void Game_Button_MouseEnter(object sender, MouseEventArgs e)
        {
            var button = (Button)sender;
            _gameViewModel.ButtonName = (Convert.ToChar(Grid.GetRow(button) + 64)).ToString() + Grid.GetColumn(button).ToString();
        }
        private void Game_Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var whiteBrush = (Brush)_brushConverter.ConvertFromString("White");
            var blackBrush = (Brush)_brushConverter.ConvertFromString("Black");

            var response = _gameViewModel.SendAction(Grid.GetRow(button)-1, Grid.GetColumn(button)-1);
            var backgroundColor = /*response.CurrentPlayerId == 1 ? blackBrush :*/ whiteBrush;
            var textColor = /*response.CurrentPlayerId == 1 ? whiteBrush :*/ blackBrush;
            button.Background = backgroundColor;
            button.Foreground = textColor;
            button.Content = response.TurnCountAsText;
            button.IsEnabled = false;

            if (response.IsGameFinished)
            {
                button.Foreground = (Brush)_brushConverter.ConvertFromString("Red");
                button.FontWeight = (FontWeight)_fontConverter.ConvertFromString("Heavy");
                GameGrid.IsEnabled = false;
                var finishWindow = new FinishWindow(_gameViewModel);
                if (response.IsGameTied)
                {
                    finishWindow.WinnerPlayer.Text = "Game";
                    finishWindow.EndResultText.Text = "Ties!";
                }
                finishWindow.ShowDialog();
            }
        }
    }
}
