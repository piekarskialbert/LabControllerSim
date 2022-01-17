using LabControllerSim.Core;
using LabControllerSim.Views;
using Prism.Events;
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

        // Metoda otwierająca główne okno symulatora
        private void SimulatorOpen()
        {
            var simulatorWindow = new SimulatorWindow();
            simulatorWindow.ShowDialog();
        }
    }
}
