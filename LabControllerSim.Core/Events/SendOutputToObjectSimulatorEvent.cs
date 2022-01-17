using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabControllerSim.Core.Events
{
    // Zdarzenie przesyłające zmienne wyjściowe z programu do symulaotra obiektu
    public class SendOutputToObjectSimulatorEvent : PubSubEvent<string>
    {
    }
}
