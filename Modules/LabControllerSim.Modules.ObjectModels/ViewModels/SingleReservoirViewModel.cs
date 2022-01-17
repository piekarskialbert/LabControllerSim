using LabControllerSim.Modules.ObjectModels.Models;
using LabControllerSim.Core.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace LabControllerSim.Modules.ObjectModels.ViewModels
{
    public class SingleReservoirViewModel : BindableBase
    {
        string inputToProgram;
        int[] INPUT = { 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] OUTPUT = { 0, 0, 0, 0, 0, 0, 0, 0 };
        public SingleReservoirModel SingleReservoir { get; set; }
        public DelegateCommand<object> MouseLeftButtonDownCommand { get; private set; }
        public DelegateCommand<object> MouseRightButtonDownCommand { get; private set; }
        public DelegateCommand<object> MouseLeftButtonUpCommand { get; private set; }
        private double[] _zCapacities = { 5, 7, 10, 20,40, 50, 100 };
        private double[] _gCapacities = { 1, 2, 3, 5, 7, 10 };

        public double[] ZCapacities { get { return _zCapacities; } }
        public double[] GCapacities { get { return _gCapacities; } }

        IEventAggregator _ea;

        public SingleReservoirViewModel(IEventAggregator ea)
        {
            SingleReservoir = new SingleReservoirModel();
            ea.GetEvent<SendOutputFromObjectSimulatorToObjectEvent>().Subscribe(ObjectLogic); // Odebranie zmiennych wyjściowych
            ea.GetEvent<ConnectProgramToObjectEvent>().Subscribe(ConnectToProgram); // Informacja o połączeniu ze sterownikiem
            ea.GetEvent<ResetObjectEvent>().Subscribe(ResetObject); // Informacja o zresetowaniu zmiennych
            MouseLeftButtonDownCommand = new DelegateCommand<object>(MouseLeftButtonDown);
            MouseLeftButtonUpCommand = new DelegateCommand<object>(MouseLeftButtonUp);
            MouseRightButtonDownCommand = new DelegateCommand<object>(MouseRightButtonDown);
            _ea = ea;
        }

        // Obłsuga zaworu zakłócającego
        private void MouseRightButtonDown(object obj)
        {
            if (obj.ToString() == "W") SingleReservoir.W = SingleReservoir.W == 0 ? 1 : 0;

        }

        private void MouseLeftButtonUp(object obj)
        {
            if (obj.ToString() == "W") SingleReservoir.W = 0;

        }

        private void MouseLeftButtonDown(object obj)
        {
            if (obj.ToString() == "W") SingleReservoir.W = 1;

        }

        // Wyłączenie możliwości zmiany wejść/wyjść po połączeniu ze sterownikiem
        private void ConnectToProgram(bool programIsConnected)
        {
            if (programIsConnected) SingleReservoir.ComboBoxIsEnabled = false;
            else SingleReservoir.ComboBoxIsEnabled = true;
        }

        // Przypisanie wyjść obiekty do wyjść wybranych w programie
        private void SetOutput()
        {

            SingleReservoir.Z1 = OUTPUT[SingleReservoir.Z1Index];
            SingleReservoir.Z2 = OUTPUT[SingleReservoir.Z2Index];
            SingleReservoir.Z3 = OUTPUT[SingleReservoir.Z3Index];
            SingleReservoir.G = OUTPUT[SingleReservoir.GIndex];
            SingleReservoir.M = OUTPUT[SingleReservoir.MIndex];
        }

        // Przypisanie wejść obiekty do wyjść wybranych w programie
        private void SetInput()
        {
            INPUT[SingleReservoir.X1Index] = SingleReservoir.X1;
            INPUT[SingleReservoir.X2Index] = SingleReservoir.X2;
            INPUT[SingleReservoir.X3Index] = SingleReservoir.X3;
            INPUT[SingleReservoir.TIndex] = SingleReservoir.T;
        }

        // Resetowanie zmiennych obiektu
        private void ResetObject(string obj)
        {
            SingleReservoir.X1 = 0;
            SingleReservoir.X2 = 0;
            SingleReservoir.X3 = 0;
            SingleReservoir.T = 0;
            SingleReservoir.Z1 = 0;
            SingleReservoir.Z2 = 0;
            SingleReservoir.Z3 = 0;
            SingleReservoir.G = 0;
            SingleReservoir.M = 0;
            SingleReservoir.WaterLevel = 0;
            SingleReservoir.TemperatureLevel = 0;
        }

        // Logika działania obiektu
        // Ustawianie zmiennych wyjściowych, kontrola poziomu wody i temperatury w zależności od stanu zmiennych
        private void ObjectLogic(string output)
        {
            if (OUTPUT[0] != Int32.Parse(output.Substring(0, 1))) OUTPUT[0] = Int32.Parse(output.Substring(0, 1));
            if (OUTPUT[1] != Int32.Parse(output.Substring(1, 1))) OUTPUT[1] = Int32.Parse(output.Substring(1, 1));
            if (OUTPUT[2] != Int32.Parse(output.Substring(2, 1))) OUTPUT[2] = Int32.Parse(output.Substring(2, 1));
            if (OUTPUT[3] != Int32.Parse(output.Substring(3, 1))) OUTPUT[3] = Int32.Parse(output.Substring(3, 1));
            if (OUTPUT[4] != Int32.Parse(output.Substring(4, 1))) OUTPUT[4] = Int32.Parse(output.Substring(4, 1));
            if (OUTPUT[5] != Int32.Parse(output.Substring(5, 1))) OUTPUT[5] = Int32.Parse(output.Substring(5, 1));
            if (OUTPUT[6] != Int32.Parse(output.Substring(6, 1))) OUTPUT[6] = Int32.Parse(output.Substring(6, 1));
            if (OUTPUT[7] != Int32.Parse(output.Substring(7, 1))) OUTPUT[7] = Int32.Parse(output.Substring(7, 1));

            SetOutput();
            if (SingleReservoir.Z1 == 1 && SingleReservoir.WaterLevel <= 1000) SingleReservoir.WaterLevel += ZCapacities[SingleReservoir.Z1Capacity]/10;
            if (SingleReservoir.Z2 == 1 && SingleReservoir.WaterLevel <= 1000) SingleReservoir.WaterLevel += ZCapacities[SingleReservoir.Z2Capacity]/10;
            if (SingleReservoir.Z3 == 1 && SingleReservoir.WaterLevel >= 0) SingleReservoir.WaterLevel -= ZCapacities[SingleReservoir.Z3Capacity]/10;
            if (SingleReservoir.W == 1) SingleReservoir.WaterLevel -= ZCapacities[SingleReservoir.WCapacity]/10;
            if (SingleReservoir.G == 1 && SingleReservoir.TemperatureLevel <= 100) SingleReservoir.TemperatureLevel += GCapacities[SingleReservoir.GCapacity]/10;
            else if (SingleReservoir.TemperatureLevel >= 0) SingleReservoir.TemperatureLevel = SingleReservoir.TemperatureLevel - 0.05;
            if (SingleReservoir.TemperatureLevel <= 0) SingleReservoir.TemperatureLevel = 0;
            if (SingleReservoir.TemperatureLevel >= 100) SingleReservoir.TemperatureLevel = 100;
            if (SingleReservoir.WaterLevel >= 1000) SingleReservoir.WaterLevel = 1000;
            if (SingleReservoir.WaterLevel <= 0) SingleReservoir.WaterLevel = 0;
            SingleReservoir.X1 = SingleReservoir.WaterLevel >= 235 ? 1 : 0;
            SingleReservoir.X2 = SingleReservoir.WaterLevel >= 555 ? 1 : 0;
            SingleReservoir.X3 = SingleReservoir.WaterLevel >= 855 ? 1 : 0;
            SingleReservoir.T = SingleReservoir.TemperatureLevel >= 80 ? 1 : 0;
            SetInput();

            inputToProgram = String.Join("", INPUT.Select(x => x.ToString()));
            _ea.GetEvent<SendInputFromObjectToObjectSimulatorEvent>().Publish(inputToProgram); // Przesłanie zmiennych wejściowych

        }
    }
}
