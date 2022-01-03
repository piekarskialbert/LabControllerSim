using System.Windows.Controls;

namespace LabControllerSim.Modules.ConsoleSimulator.Views
{
    /// <summary>
    /// Interaction logic for ConsoleSimulatorUserControl
    /// </summary>
    public partial class ConsoleSimulatorUserControl : UserControl
    {
        public ConsoleSimulatorUserControl()
        {
            InitializeComponent();
            this.TextBox.SelectionChanged += (sender, e) => MoveCustomCaret();
            this.TextBox.LostFocus += (sender, e) => Caret.Visibility = System.Windows.Visibility.Collapsed;
            this.TextBox.GotFocus += (sender, e) => Caret.Visibility = System.Windows.Visibility.Visible;
        }
        private void MoveCustomCaret()
        {
            var caretLocation = TextBox.GetRectFromCharacterIndex(TextBox.CaretIndex).Location;

            if (!double.IsInfinity(caretLocation.X))
            {
                Canvas.SetLeft(Caret, caretLocation.X);
            }

            if (!double.IsInfinity(caretLocation.Y))
            {
                Canvas.SetTop(Caret, caretLocation.Y);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ScrollViewer.ScrollToBottom();
        }
    }
}
