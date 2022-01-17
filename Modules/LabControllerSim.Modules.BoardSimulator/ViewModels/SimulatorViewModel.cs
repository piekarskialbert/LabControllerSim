using LabControllerSim.Core;
using LabControllerSim.Modules.BoardSimulator.Views;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace LabControllerSim.Modules.BoardSimulator.ViewModels
{
    public class SimulatorViewModel
    {
        public ICommand OpenObjectSimulatorCommand { get; }
        public ICommand OpenConsoleSimulatorCommand { get; }

        Dispatcher consoleDispatcher;
        Dispatcher objectDispatcher;

        public SimulatorViewModel(IEventAggregator ea)
        {
            OpenObjectSimulatorCommand = new RelayCommand(ObjectSimulatorOpen);
            OpenConsoleSimulatorCommand = new RelayCommand(ConsoleSimulatorOpen);
        }
        
        // Otwarcie okna symulatora konsoli w nowym wątku
        private void ConsoleSimulatorOpen()
        {
            Thread newConsoleSimulatorThread = new Thread(new ThreadStart(() =>
            {
                SynchronizationContext.SetSynchronizationContext(
                    new DispatcherSynchronizationContext(
                        Dispatcher.CurrentDispatcher));
                consoleDispatcher = Dispatcher.CurrentDispatcher;
                var consoleSimulatorWindow = new ConsoleSimulatorWindow();
                consoleSimulatorWindow.Closed += (s, e) => {
                    consoleDispatcher.BeginInvokeShutdown(DispatcherPriority.Background);
                };
                consoleSimulatorWindow.Show();
                System.Windows.Threading.Dispatcher.Run();
            }));
            newConsoleSimulatorThread.SetApartmentState(ApartmentState.STA);
            newConsoleSimulatorThread.IsBackground = true;
            newConsoleSimulatorThread.Start();
        }

        // Otwarcie okna symulatora obiektu w nowym wątku
        private void ObjectSimulatorOpen()
        {
            Thread newObjectSimulatorThread = new Thread(new ThreadStart(() =>
            {
                SynchronizationContext.SetSynchronizationContext(
                    new DispatcherSynchronizationContext(
                        Dispatcher.CurrentDispatcher));
                objectDispatcher = Dispatcher.CurrentDispatcher;
                var objectSimulatorWindow = new ObjectSimulatorWindow();
                objectSimulatorWindow.Closed += (s, e) => {
                    objectDispatcher.BeginInvokeShutdown(DispatcherPriority.Background);
                };
                objectSimulatorWindow.Show();
                System.Windows.Threading.Dispatcher.Run();
            }));
            newObjectSimulatorThread.SetApartmentState(ApartmentState.STA);
            newObjectSimulatorThread.IsBackground = true;
            newObjectSimulatorThread.Start();
        }

        // Zamknięcie okien symulatora konsoli i obiektów
        public void CloseSimulatorWindows()
        {
            consoleDispatcher?.BeginInvokeShutdown(DispatcherPriority.Background);
            objectDispatcher?.BeginInvokeShutdown(DispatcherPriority.Background);
        }
    }
}
