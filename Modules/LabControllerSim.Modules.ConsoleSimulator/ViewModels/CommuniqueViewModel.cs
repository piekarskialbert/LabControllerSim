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
        public string Text { get { return _text; } set { OnPropertyChange(ref _text, value); } }

        public CommuniqueViewModel(IEventAggregator ea)
        {
            ea.GetEvent<SendCharFromProgramToConsoleEvent>().Subscribe(GetChar); //Zdarzenie odbierające znak z programu
        }

        //Dodanie znaku do zawartości konsoli
        private void GetChar(string charOutput)
        {
            Text += charOutput;
        }

    }
}
