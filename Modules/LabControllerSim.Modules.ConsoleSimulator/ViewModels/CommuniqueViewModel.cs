using LabControllerSim.Core;
using LabControllerSim.Core.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabControllerSim.Modules.ConsoleSimulator.ViewModels
{
    public class CommuniqueViewModel : ObservableObject
    {
        private string _text;
        private string buffor;
        long lastMillis;
        public string Text { get { return _text; } set { OnPropertyChange(ref _text, value); } }

        public CommuniqueViewModel(IEventAggregator ea)
        {
            ea.GetEvent<SendCharFromProgramToConsoleEvent>().Subscribe(GetChar);
            lastMillis = Millis();

        }

        private void GetChar(string charOutput)
        {
            if (Millis() - lastMillis >= 500)
            {
                Text += "\n";
            }
            Text += charOutput;
            lastMillis = Millis();
        }

        long Millis()
        {
            return (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond);
        }
    }
}
