using SampleDataGridApplication.ViewModels;
using System.Windows;

namespace SampleDataGridApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as MainViewModel;
            vm.LostFocusCommand.Execute(sender);
        }
    }
}