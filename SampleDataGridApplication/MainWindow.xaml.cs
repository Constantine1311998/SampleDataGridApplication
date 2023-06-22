using AssistantLibrary;
using System;
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
            this.MasterButton.Click += MasterButtonClick;
        }

        private void MasterButtonClick(object sender, RoutedEventArgs e)
        {
           PromptWindow window = new PromptWindow();
            window.ShowDialog();
        }
    }
}