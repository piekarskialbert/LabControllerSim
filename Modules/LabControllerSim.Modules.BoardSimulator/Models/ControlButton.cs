using LabControllerSim.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabControllerSim.Modules.BoardSimulator.Models
{
    public class ControlButton : ObservableObject
    {
        private bool _isEnabled;

        public bool IsEnabled { get { return _isEnabled; } set { OnPropertyChange(ref _isEnabled, value); } }

    }
}