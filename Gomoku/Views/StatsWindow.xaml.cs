using Gomoku.ViewModels;
using System.Windows;

namespace Gomoku.Views
{
    /// <summary>
    /// Interaction logic for StatsWindow.xaml
    /// </summary>
    public partial class StatsWindow : Window
    {
        private readonly StatsViewModel _statsViewModel;
        public StatsWindow()
        {
            _statsViewModel = new StatsViewModel();
            InitializeComponent();
            DataContext = _statsViewModel;
        }

        private void Stats_Close_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
