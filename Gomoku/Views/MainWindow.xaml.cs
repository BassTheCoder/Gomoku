using System.Windows;

namespace Gomoku.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool RulesActive = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void NG_Button_Click(object sender, RoutedEventArgs e)
        {
            LobbyWindow lobbyWindow = new LobbyWindow();
            lobbyWindow.ShowDialog();
        }

        private void Rules_Button_Click(object sender, RoutedEventArgs e)
        {
            RulesWindow rulesWindow = new RulesWindow();
            rulesWindow.ShowDialog();
        }

        private void Stats_Button_Click(object sender, RoutedEventArgs e)
        {
            StatsWindow statsWindow = new StatsWindow();
            statsWindow.ShowDialog();
        }
    }
}
