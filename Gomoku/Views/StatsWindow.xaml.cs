using Gomoku.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
