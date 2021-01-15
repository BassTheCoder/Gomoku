using Gomoku.ViewModels;
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
            if (Player1Name.Text != "" && Player2Name.Text != "")
            {
                this.Close();
                GameWindow gameWindow = new GameWindow(_gameViewModel);
                _gameViewModel.LoadPlayers();
                gameWindow.ShowDialog();
            }
            else
            {
                 if (Player1Name.Text == "")
                 {
                     Player1NullCase.Text = "Enter Player 1 name!";
                 }
                 else
                 {
                     Player1NullCase.Text = "";
                 }
                 if (Player2Name.Text == "")
                 {
                     Player2NullCase.Text = "Enter Player 2 name!";
                 }
                 else
                 {
                     Player2NullCase.Text = "";
                 }
            }
        }
    }
}
