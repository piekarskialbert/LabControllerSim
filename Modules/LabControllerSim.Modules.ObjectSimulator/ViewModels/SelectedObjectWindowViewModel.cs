using LabControllerSim.Core;
using LabControllerSim.Core.Events;
using LabControllerSim.Modules.ObjectSimulator.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace LabControllerSim.Modules.ObjectSimulator.ViewModels
{
    public class SelectedObjectWindowViewModel : BindableBase
    {
        public string ActualObject { get; set; }
        public ICommand ConnectProgramToObjectSimulatorCommand { get; }
        public ICommand DisconnectProgramFromObjectSimulatorCommand { get; }
        public ICommand ResetObjectCommand { get; }
        IEventAggregator _ea;
        public bool programIsConnected;
        public ControlButton ConnectButton { get; private set; }
        public ControlButton DisconnectButton { get; private set; }

        private string _selectedObject;
        public string SelectedObject
        {
            get { return _selectedObject; }
            set { SetProperty(ref _selectedObject, value); }
        }
        private string _selectedObjectLabel = "";
        public string SelectedObjectLabel
        {
            get { return _selectedObjectLabel; }
            set { SetProperty(ref _selectedObjectLabel, value); }
        }


        public ControlButton ChooseObjectButton { get; private set; }
        public SelectedObjectWindowViewModel(IEventAggregator ea)
        {
            _ea = ea;
            ea.GetEvent<SendObjectNameEvent>().Subscribe((e) => { SelectedObject = e[1];SelectedObjectLabel = e[0]; }) ; //Przypisanie wybranego obiektu do okna
            ConnectButton = new ControlButton() { IsEnabled = true };
            DisconnectButton = new ControlButton();
            ChooseObjectButton = new ControlButton() { IsEnabled = true }; ;
            ConnectProgramToObjectSimulatorCommand = new RelayCommand(ConnectToProgram, () => ConnectButton.IsEnabled); // Wywołanie funkcji po naciśnięciu przycisku Połącz
            DisconnectProgramFromObjectSimulatorCommand = new RelayCommand(DisconnectProgram, () => DisconnectButton.IsEnabled); // wywołanie funkcji na naciśnięciu przycisku Rozłącz
            ResetObjectCommand = new RelayCommand(ResetjObject);
            ea.GetEvent<SendOutputToObjectSimulatorEvent>().Subscribe(GetOutput); // Odebranie zmiennych wyjściowych z wirtualnego sterownika
            ea.GetEvent<SendInputFromObjectToObjectSimulatorEvent>().Subscribe(GetInput); // Odebranie zmiennych wejściowych z obiektu
        }

        // Resetowanie zmiennych obiektu
        private void ResetjObject()
        {
            _ea.GetEvent<ResetObjectEvent>().Publish(null);
        }

        // Wysłanie zmiennych wejściowych do wirtualnego sterownika
        private void GetInput(string intputFromObject)
        {
            _ea.GetEvent<SendInputFromObjectSimulatorToProgramEvent>().Publish(intputFromObject);
        }

        // Wsyłanie zmiennych wyjściowych do obiektu, jeżeli symulator jest połączony
        private void GetOutput(string outputFromProgram)
        {
            if (programIsConnected)
            {
                _ea.GetEvent<SendOutputFromObjectSimulatorToObjectEvent>().Publish(outputFromProgram);
            }

        }

        // Połączenie obiektu z wirtualnym sterownikiem
        private void ConnectToProgram()
        {
            DisconnectButton.IsEnabled = true;
            ConnectButton.IsEnabled = false;
            programIsConnected = true;
            _ea.GetEvent<ConnectProgramToObjectEvent>().Publish(programIsConnected);
        }

        // Rozłączenie obiektu z wirtualnym sterownikiem
        private void DisconnectProgram()
        {
            DisconnectButton.IsEnabled = false;
            ConnectButton.IsEnabled = true;
            programIsConnected = false;
            _ea.GetEvent<ConnectProgramToObjectEvent>().Publish(programIsConnected);
        }
    }
}
