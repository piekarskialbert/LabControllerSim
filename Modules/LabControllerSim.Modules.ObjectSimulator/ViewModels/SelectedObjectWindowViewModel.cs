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
            ea.GetEvent<SendObjectNameEvent>().Subscribe((e) => { SelectedObject = e[1];SelectedObjectLabel = e[0]; }) ;
           // SelectedObject = "SingleReservoir"
            ConnectButton = new ControlButton() { IsEnabled = true };
            DisconnectButton = new ControlButton();
            ChooseObjectButton = new ControlButton() { IsEnabled = true }; ;
            ConnectProgramToObjectSimulatorCommand = new RelayCommand(ConnectToProgram, () => ConnectButton.IsEnabled);
            DisconnectProgramFromObjectSimulatorCommand = new RelayCommand(DisconnectProgram, () => DisconnectButton.IsEnabled);
            ResetObjectCommand = new RelayCommand(ResetjObject);
            ea.GetEvent<SendOutputToObjectSimulatorEvent>().Subscribe(GetOutput);
            ea.GetEvent<SendInputFromObjectToObjectSimulatorEvent>().Subscribe(GetInput);
        }


        private void ResetjObject()
        {
            _ea.GetEvent<ResetObjectEvent>().Publish(null);
        }


        private void GetInput(string intputFromObject)
        {
            _ea.GetEvent<SendInputFromObjectToProgramEvent>().Publish(intputFromObject);
        }


        private void GetOutput(string outputFromProgram)
        {
            if (programIsConnected)
            {
                _ea.GetEvent<SendOutputFromObjectSimulatorToObjectEvent>().Publish(outputFromProgram);
            }

        }

        private void ConnectToProgram()
        {
            DisconnectButton.IsEnabled = true;
            ConnectButton.IsEnabled = false;
            programIsConnected = true;
            _ea.GetEvent<ConnectProgramToObjectEvent>().Publish(programIsConnected);
        }
        private void DisconnectProgram()
        {
            DisconnectButton.IsEnabled = false;
            ConnectButton.IsEnabled = true;
            programIsConnected = false;
            _ea.GetEvent<ConnectProgramToObjectEvent>().Publish(programIsConnected);
        }
    }
}
