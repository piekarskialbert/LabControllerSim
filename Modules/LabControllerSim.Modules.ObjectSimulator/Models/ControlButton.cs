using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabControllerSim.Modules.ObjectSimulator.Models
{
    public class ControlButton
    {
        private bool _isEnabled;

        public bool IsEnabled { get { return _isEnabled; } set { _isEnabled = value; } }
    }
}
