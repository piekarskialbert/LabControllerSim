using LabControllerSim.Core;
using LabControllerSim.Core.Events;
using LabControllerSim.Modules.ObjectSimulator.Models;
using LabControllerSim.Modules.ObjectSimulator.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace LabControllerSim.Modules.ObjectSimulator.ViewModels
{
    public class ObjectSimulatorUserControlViewModel : BindableBase
    {
        IEventAggregator _ea;
        public ICommand ChooseObjectCommand { get; }
        public IList<string> ObjectsLabels { get; set; }
        public IList<string> ObjectsNames { get; set; }

        private int _selectedObjectIndex;
        public int SelectedObjectIndex
        {
            get { return _selectedObjectIndex; }
            set { SetProperty(ref _selectedObjectIndex, value); }
        }
        public ControlButton ChooseObjectButton { get; private set; }
        public ObjectSimulatorUserControlViewModel(IEventAggregator ea)
        {
            _ea = ea;
            ObjectsLabels = new List<string> { "Zbiornik" };
            ObjectsNames = new List<string> { "SingleReservoir" };
            ChooseObjectButton = new ControlButton() { IsEnabled = true  };
            ChooseObjectCommand = new RelayCommand(ChooseObject, () => ChooseObjectButton.IsEnabled);
           
            
        }
   
        // Wybranie obiektu z listy
        private void ChooseObject()
        {
            var objectWindow = new SelectedObjectWindow();
            _ea.GetEvent<SendObjectNameEvent>().Publish(new string[] {ObjectsLabels[_selectedObjectIndex],ObjectsNames[_selectedObjectIndex]});
            objectWindow.ShowDialog();
        }

  
    }
}
