using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabControllerSim.Core.Events
{
    // Zdarzenie przesyłające zmienne wyjściowe z symulatora obiektu do wybranego obiektu
    public class SendOutputFromObjectSimulatorToObjectEvent : PubSubEvent<string>
    {
    }
}
