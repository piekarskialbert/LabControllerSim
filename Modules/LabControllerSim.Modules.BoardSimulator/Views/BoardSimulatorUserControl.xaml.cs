using LabControllerSim.Core.Events;
using LabControllerSim.Modules.BoardSimulator.Models;
using Prism.Events;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace LabControllerSim.Modules.BoardSimulator.Views
{
    /// <summary>
    /// Interaction logic for BoardView
    /// </summary>
    public partial class BoardSimulatorUserControl : UserControl
    {
        public BoardSimulatorUserControl()
        {
           
            InitializeComponent();

        }
        //
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
