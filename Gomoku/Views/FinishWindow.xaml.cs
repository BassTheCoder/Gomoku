using Gomoku.ViewModels;
using System.Windows;

namespace Gomoku.Views
{
    /// <summary>
    /// Interaction logic for FinishWindow.xaml
    /// </summary>
    public partial class FinishWindow : Window
    {
        private readonly GameViewModel _gameViewModel;
        public FinishWindow(GameViewModel gameViewModel)
        {
            InitializeComponent();
            _gameViewModel = gameViewModel;
            DataContext = _gameViewModel;
        }

        private void Finish_Close_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
