using LabControllerSim.Core;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace LabControllerSim.Modules.ConsoleSimulator.ViewModels
{
    public class ConsoleSimulatorUserControlViewModel : BindableBase
    {
        
        public CommuniqueViewModel Communique { get; set; }
        public InputCharViewModel InputChar { get; set; }
        public ICommand ClearConsoleCommand { get; }
        public ConsoleSimulatorUserControlViewModel(IEventAggregator ea)
        {
            Communique = new CommuniqueViewModel(ea);
            InputChar = new InputCharViewModel(ea);
            ClearConsoleCommand = new RelayCommand(() => Communique.Text = ""); // Czyszczenie zawartości konsoli
        }
    }
}
