using LabControllerSim.Core;
using LabControllerSim.Core.Events;
using LabControllerSim.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace LabControllerSim.ViewModels
{
    public class SimulatorWindowViewModel : BindableBase
    {
        public ICommand CloseWindowCommand { get; }
        public DelegateCommand<KeyEventArgs> KeyDownCommand { get; private set; }
        public DelegateCommand<KeyEventArgs> KeyUpCommand { get; private set; }
        private string _title = "Symulator";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public SimulatorWindowViewModel(IEventAggregator ea)
        {
            CloseWindowCommand = new RelayCommand(() => ea.GetEvent<CloseSimulatorWindowEvent>().Publish(null)); // Wysłanie informacji o zamknięciu okna symulatora
            KeyUpCommand = new DelegateCommand<KeyEventArgs>((e) => ea.GetEvent<KeyUpWindowEvent>().Publish(e)); // Przesłanie informacji o puszczeniu przycisku na klawiaturze
            KeyDownCommand = new DelegateCommand<KeyEventArgs>((e) => ea.GetEvent<KeyDownWindowEvent>().Publish(e)); // Przesłanie informacji o naciśnięciu przycisku na klawiaturze
        }  
    }
}
