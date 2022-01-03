using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LabControllerSim.Modules.BoardSimulator.ViewModels
{
    public class ObjectSimulatorWindowViewModel : BindableBase
    {
        private string _title = "Symulator obiektów";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public ObjectSimulatorWindowViewModel()
        {

        }
    }
}
