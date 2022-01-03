using LabControllerSim.Core;
using LabControllerSim.Views;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LabControllerSim.ViewModels
{
    public class SimulatorViewModel
    {
        public ICommand OpenSimulatorCommand { get; }

        public SimulatorViewModel(IEventAggregator ea)
        {
            OpenSimulatorCommand = new RelayCommand(SimulatorOpen);
        }

        private void SimulatorOpen()
        {
            var simulatorWindow = new SimulatorWindow();
            simulatorWindow.ShowDialog();
        }
    }
}
