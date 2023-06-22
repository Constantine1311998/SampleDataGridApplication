using System.Windows;
using System.Windows.Controls;

namespace AssistantLibrary
{
    /// <summary>
    /// Interaction logic for AssistantUserControl.xaml
    /// </summary>
    public partial class AssistantUserControl : UserControl
    {
        public AssistantUserControl()
        {
            InitializeComponent();
        }

        private void MasterButton_Click(object sender, RoutedEventArgs e)
        {
            PromptWindow window = new PromptWindow();
            window.ShowDialog();
        }
    }
}