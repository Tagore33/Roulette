using System.Windows;
using Roulette.ViewModels;

namespace Roulette
{
    public partial class MainWindow : Window
    {
        public RouletteViewModel? RouletteViewModel;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += RouletteWindow_Loaded;
        }

        private void RouletteWindow_Loaded(object sender, RoutedEventArgs e)
        {
            RouletteViewModel = new RouletteViewModel();
            StandardBoxesGridIC.ItemsSource = RouletteViewModel.StandardBoxesVM.StandardBoxes;
            DataContext = RouletteViewModel;
        }
    }
}
