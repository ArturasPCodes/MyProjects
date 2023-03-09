using MusicApp.Windows;
using System.Windows;

namespace MusicApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void nDataAccessBtn_Click(object sender, RoutedEventArgs e)
        {
            var dataAccessWindow = new DataAccessWindow();
            dataAccessWindow.ShowDialog();
        }

        private void nSearchBtn_Click(object sender, RoutedEventArgs e)
        {
            var searchWindow = new SearchWindow();
            searchWindow.ShowDialog();
        }

        private void nTopStatsBtn_Click(object sender, RoutedEventArgs e)
        {
            var topStatsWindow = new TopStatsWindow();
            topStatsWindow.ShowDialog();
        }
    }
}
