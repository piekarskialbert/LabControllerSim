using LabControllerSim.Core;
using LabControllerSim.Core.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LabControllerSim.Modules.ConsoleSimulator.ViewModels
{
    public class InputCharViewModel : ObservableObject
    {
        IEventAggregator _ea;
        private string _text;
        string _lastChar = "";
        public string Text { get { return _text; } set { OnPropertyChange(ref _text, value); SendChar(); } }
        public string LastChar { get { return _lastChar; } set { OnPropertyChange(ref _lastChar, value); } }
        public InputCharViewModel(IEventAggregator ea)
        {
            _ea = ea;
        }
        private void SendChar()
        {
            if (!string.IsNullOrEmpty(_text))
            {
                if (!string.IsNullOrWhiteSpace(_text.Substring(2)))
                {
                    _ea.GetEvent<SendCharFromConsoleToProgramEvent>().Publish(_text.Substring(2));
                }
                LastChar = _text.Substring(2);     
                Text = "";
            }
        }
    }
}
