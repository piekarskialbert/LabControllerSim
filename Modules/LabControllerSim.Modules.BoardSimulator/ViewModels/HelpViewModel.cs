using LabControllerSim.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LabControllerSim.Modules.BoardSimulator.ViewModels
{
    public class HelpViewModel
    {
        public ICommand HelpCommand { get; }
        public HelpViewModel()
        {
            HelpCommand = new RelayCommand(DisplayHelp);
        }


        private void DisplayHelp()
        {
            var helpDialog = new HelpDialog();
            helpDialog.ShowDialog();
        }
    }
}
