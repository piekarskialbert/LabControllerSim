using LabControllerSim.Core;
using LabControllerSim.Core.Events;
using LabControllerSim.Views;
using Prism.Common;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LabControllerSim.ViewModels
{
    public class HelpViewModel : ObservableObject
    {
        public ICommand HelpCommand { get; }
        public ICommand AboutProgramCommand { get; }
        public HelpViewModel()
        {
            HelpCommand = new RelayCommand(DisplayHelp);
            AboutProgramCommand = new RelayCommand(DisplayAboutProgram);
        }

        // Metoda wyświetlająca informacje o programie
        private void DisplayAboutProgram()
        {
            var aboutAProgramDialog = new AboutProgramDialog();
            aboutAProgramDialog.ShowDialog();
        }

        // Metoda wyświetlająca okno pomocy
        private void DisplayHelp()
        {
            var helpDialog = new HelpDialog();
            helpDialog.ShowDialog();
        }

    }
}
