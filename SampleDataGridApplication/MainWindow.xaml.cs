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
        /// <summary>
        /// When text box looses focus this will fire lost focus command.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as MainViewModel;
            vm.LostFocusCommand.Execute(sender);
        }

        /// <summary>
        /// Fires lost focus command when Enter key is hit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filePathTxtBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                var vm = this.DataContext as MainViewModel;
                vm.LostFocusCommand.Execute(sender);
            }
        }
    }
}