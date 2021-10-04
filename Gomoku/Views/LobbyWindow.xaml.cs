using Gomoku.ViewModels;
using System;
using System.Windows;

namespace Gomoku.Views
{
    /// <summary>
    /// Interaction logic for LobbyWindow.xaml
    /// </summary>
    public partial class LobbyWindow : Window
    {
        private GameViewModel _gameViewModel;

        public LobbyWindow()
        {
            InitializeComponent();
            _gameViewModel = new GameViewModel();
            DataContext = _gameViewModel;
        }

        private void Lobby_Rules_Button_Click(object sender, RoutedEventArgs e)
        {
            RulesWindow rulesWindow = new RulesWindow();
            rulesWindow.ShowDialog();
        }

        private void Lobby_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Lobby_Go_Button_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(Player1Name.Text) && !String.IsNullOrEmpty(Player2Name.Text))
            {
                if (Player1Name.Text != Player2Name.Text)
                {
                    this.Close();
                    GameWindow gameWindow = new GameWindow(_gameViewModel);
                    //_gameViewModel.LoadPlayers();
                    gameWindow.ShowDialog();
                }
                else
                {
                    Player1ErrorCase.Text = "Players can't have the same names!";
                    Player2ErrorCase.Text = "Players can't have the same names!";
                }
            }
            else
            {
                if (String.IsNullOrEmpty(Player1Name.Text))
                {
                    Player1ErrorCase.Text = "Enter Player 1 name!";
                }
                else
                {
                    Player1ErrorCase.Text = "";
                }
                if (String.IsNullOrEmpty(Player2Name.Text))
                {
                    Player2ErrorCase.Text = "Enter Player 2 name!";
                }
                else
                {
                    Player2ErrorCase.Text = "";
                }
            }
        }
    }
}
